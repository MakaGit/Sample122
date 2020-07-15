using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;

public class SceneController : MonoBehaviour
{
	[SerializeField] private TextAsset inkJSONAsset = null;

	[SerializeField] private Canvas Maincanvas = null;
	[SerializeField] private Canvas canvas = null;
	[SerializeField] private Button buttonPrefab = null;
	[SerializeField] private GameObject choiseTextPanel = null;
	[SerializeField] private VideoPlayer videoPlayer = null;
	[SerializeField] private AudioSource audioSource = null;
	[SerializeField] private Button InputButton = null;
	[SerializeField] private Button MenuButton = null;

	[SerializeField] private Subject _mainSub;
	[SerializeField] private Subject _leftSub;
	[SerializeField] private Subject _rightSub;
	[SerializeField] private Background _background;

	public Story story;

	private Subject currentSub = null;
	private CanvasGroup canvasGroup = null;

	public static event Action<Story> OnCreateStory;
	public Action OnStep;
	public Action Call;

	private TaskManager _taskManager = new TaskManager();

	private string StoryText;

	private bool canContinue = false;

	private char dot = '.';

	private Coroutine timer = null;


	void Awake()
	{
		currentSub = null;
		OnStep += Continue;
		canvasGroup = canvas.GetComponent<CanvasGroup>();
		StartStory();
	}

	void StartStory()
	{
		story = new Story(inkJSONAsset.text);
		if (OnCreateStory != null) OnCreateStory(story);

		if (PlayerPrefs.HasKey("Progress"))
		{
			story.state.LoadJson(SaveManager.Instance.LoadProgress());

			_leftSub.ChangeCharacter(SaveManager.Instance.LoadLeftCharacterIndex());
			_leftSub.ChangeName(SaveManager.Instance.LoadLeftCharacterName());

			_rightSub.ChangeCharacter(SaveManager.Instance.LoadRightCharacterIndex());
			_rightSub.ChangeName(SaveManager.Instance.LoadRightCharacterName());

			CompareBackgroundTags(SaveManager.Instance.LoadBackground());
			_taskManager.AddTask(this, this.ChangeMusic(SaveManager.Instance.LoadMusic()), Call);
		}
		else
		{
			story.variablesState["Virus_points"] = SaveManager.Instance.LoadPointsForNewChapter("Virus_points");
			story.variablesState["Cure_points"] = SaveManager.Instance.LoadPointsForNewChapter("Cure_points");
			SaveManager.Instance.LoadAchievementsForNewChapter(SaveManager.Instance.GetCurrentScene());

		}

		RefreshView();
	}


	public void OnGameplayScreenClick()
	{
		if (canContinue)
		{
			canContinue = false;
			RefreshView();
		}
	}

	private void Continue()
	{
		canContinue = true;
	}



	void RefreshView()
	{
		SaveManager.Instance.SaveProgress(story.state.ToJson());

		RemoveChildren();
		MenuButton.interactable = true;

		if (story.canContinue)
		{
			StoryText = story.Continue();

			List<string> tagsList = story.currentTags;
			foreach (string tag in tagsList)
			{
				CompareStoryTags(tag);
			}
		}
		else if (story.currentChoices.Count > 0)
		{
			Debug.Log("choise");
			InputButton.gameObject.SetActive(false);
			MenuButton.interactable = false;
			if (currentSub != null) _taskManager.AddTask(currentSub, currentSub.MovingOffTheScreen(), Call);
			_taskManager.AddTask(_background, _background.MovingToLeftPosition(), Call);
			_taskManager.AddTask(_leftSub, _leftSub.EmptyMovingToTheScreen(), Call);
			currentSub = _leftSub;
			canvasGroup.DOFade(1.0f, 1f);
			CreateChoiseTextPanel(StoryText);

			for (int i = 0; i < story.currentChoices.Count; i++)
			{
				Choice choice = story.currentChoices[i];
				Button button = CreateChoiceView(choice.text);
				button.onClick.AddListener(delegate
				{
					OnClickChoiceButton(choice);
				});
			}
		}
		else
		{
			_taskManager.AddTask(this, this.AudioFade(), Call);

			UserInterfaceManager.Instance.EnablePanel(UIPanelType.ChapterCompletePanel);

			SaveManager.Instance.DeleteChapterProgress();
			SaveManager.Instance.UnlockNextChapter();
			SaveManager.Instance.SavePointsEndOfChapter("Virus_points", (int)story.variablesState["Virus_points"]);
			SaveManager.Instance.SavePointsEndOfChapter("Cure_points", (int)story.variablesState["Cure_points"]);
		}
	}

	void OnClickChoiceButton(Choice choice)
	{
		story.ChooseChoiceIndex(choice.index);
		canvasGroup.DOFade(0.0f, 0.5f);
		if (timer != null)
		{
			StopCoroutine(timer);
			timer = null;
		}
		RefreshView();
		InputButton.gameObject.SetActive(true);
	}

	Button CreateChoiceView(string text)
	{
		Button choice = Instantiate(buttonPrefab) as Button;
		choice.transform.SetParent(canvas.transform, false);

		TMP_Text choiceText = choice.GetComponentInChildren<TMP_Text>();
		choiceText.text = text;

		return choice;
	}

	GameObject CreateChoiseTextPanel(string text)
	{
		GameObject panel = Instantiate(choiseTextPanel) as GameObject;
		panel.transform.SetParent(canvas.transform, false);
		TMP_Text Text = panel.GetComponentInChildren<TMP_Text>();
		Text.text = text;

		return panel;
	}

	void RemoveChildren()
	{
		int childCount = canvas.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i)
		{
			GameObject.Destroy(canvas.transform.GetChild(i).gameObject);
		}
	}

	private IEnumerator choiseTimer(int index)
	{
		yield return new WaitForSeconds(10.0f);
		story.ChooseChoiceIndex(index);
		canvasGroup.DOFade(0.0f, 0.5f);
		RefreshView();
		InputButton.gameObject.SetActive(true);

	}

	private void CompareStoryTags(string tags)
	{
		int index = tags.IndexOf("background");
		if (index == 0)
		{
			tags = tags.Substring(11);
			CompareBackgroundTags(tags);
			return;
		}

		index = tags.IndexOf("character");
		if (index == 0)
		{
			tags = tags.Substring(10);
			CompareCharacterTags(tags);
			return;
		}

		index = tags.IndexOf("music");
		if (index == 0)
		{
			tags = tags.Substring(6);
			int x = 0;
			int.TryParse(tags, out x);
			_taskManager.AddTask(this, this.ChangeMusic(x), Call);
			return;
		}

		index = tags.IndexOf("achievement");
		if (index == 0)
		{
			tags = tags.Substring(12);
			int x = 0;
			int.TryParse(tags, out x);
			SaveManager.Instance.SetAchievement(x);
			return;
		}

		index = tags.IndexOf("choiseTimer");
		if (index == 0)
		{
			tags = tags.Substring(12);
			int x = 0; 
			int.TryParse(tags, out x);
			RefreshView();
			timer = StartCoroutine(choiseTimer(x));
			return;
		}

		index = tags.IndexOf("video");
		if (index == 0)
		{
			tags = tags.Substring(6);
			int x = 0;
			int.TryParse(tags, out x);
			_taskManager.AddTask(this, this.ShowVideo(x), OnStep);
			return;
		}

		index = tags.IndexOf("photo");
		if (index == 0)
		{
			tags = tags.Substring(6);
			int x = 0;
			int.TryParse(tags, out x);
			_taskManager.AddTask(this, this.ShowPhoto(x), OnStep);
			return;
		}

		switch (tags)
		{
			case "mainSub":
				_taskManager.AddTask(_background, _background.MovingToMiddlePosition(), Call);
				SubStep(_mainSub);
				break;

			case "leftSub":
				_taskManager.AddTask(_background, _background.MovingToLeftPosition(), Call);
				SubStep(_leftSub);
				break;

			case "rightSub":
				_taskManager.AddTask(_background, _background.MovingToRightPosition(), Call);
				SubStep(_rightSub);
				break;

			case "refresh":
				RefreshView();
				break;

			default:
				throw new Exception("Incorrect tag in CompareStoryTags : " + tags);
		}
	}

	private void SubStep(Subject sub)
	{
		if (currentSub == null)
		{
			currentSub = sub;
			if (StoryText[0] == dot)
			{
				_taskManager.AddTask(currentSub, currentSub.EmptyMovingToTheScreen(), OnStep);
			}
			else
			{
				_taskManager.AddTask(currentSub, currentSub.MovingToTheScreen(StoryText), OnStep);
			}
		}
		else if (currentSub == sub)
		{
			if (StoryText[0] == dot)
			{
				_taskManager.AddTask(currentSub, currentSub.EmptyMovingToTheScreen(), OnStep);
			}
			else
			{
				_taskManager.AddTask(currentSub, currentSub.TextStep(StoryText), OnStep);
			}
		}
		else
		{
			_taskManager.AddTask(currentSub, currentSub.MovingOffTheScreen(), Call);
			currentSub = sub;
			if (StoryText[0] == dot)
			{
				_taskManager.AddTask(currentSub, currentSub.EmptyMovingToTheScreen(), OnStep);
			}
			else
			{
				_taskManager.AddTask(currentSub, currentSub.MovingToTheScreen(StoryText), OnStep);
			}
		}
	}

	private void CompareBackgroundTags(string tag)
	{
		switch (tag)
		{
			case "Church":
				ChangeCurrentBackground(0, tag);
				break;

			case "DanaRoomDay":
				ChangeCurrentBackground(1, tag);
				break;

			case "DanaRoomNight":
				ChangeCurrentBackground(2, tag);
				break;

			case "HouseKarp":
				ChangeCurrentBackground(3, tag);
				break;

			case "Campfire":
				ChangeCurrentBackground(4, tag);
				break;

			case "DaughtersСhamber":
				ChangeCurrentBackground(5, tag);
				break;

			case "Corridor":
				ChangeCurrentBackground(6, tag);
				break;

			case "Village":
				ChangeCurrentBackground(7, tag);
				break;

			case "Cabinet":
				ChangeCurrentBackground(8, tag);
				break;

			case "CabinetDoc":
				ChangeCurrentBackground(9, tag);
				break;

			case "Corridor2":
				ChangeCurrentBackground(10, tag);
				break;

			default:
				throw new Exception("Incorrect background tag in CompareBackgroundTags()");
		}
	}
	private void ChangeCurrentBackground(int index, string tag)
	{
		HideSub();
		_taskManager.AddTask(_background, _background.ChangeBackground(index), OnStep);
		SaveManager.Instance.SaveBackground(tag);
	}

	private void CompareCharacterTags(string tag)
	{
		switch (tag)
		{
			case "Agapa":
				ChangeCurrentCharacter(0, "Агапа");
				break;

			case "AgapaRight":
				ChangeCurrentCharacter(7, "Агапа");
				break;

			case "Aglaya":
				ChangeCurrentCharacter(1, "Аглая");
				break;

			case "Doc":
				ChangeCurrentCharacter(2, "Доктор");
				break;

			case "DocLeft":
				ChangeCurrentCharacter(8, "Доктор");
				break;

			case "Karp":
				ChangeCurrentCharacter(3, "Карп");
				break;

			case "KarpRight":
				ChangeCurrentCharacter(9, "Карп");
				break;

			case "Safo":
				ChangeCurrentCharacter(4, "Сафо");
				break;

			case "SafoLeft":
				ChangeCurrentCharacter(10, "Сафо");
				break;

			case "Sanitar":
				ChangeCurrentCharacter(5, "Санитар");
				break;

			case "Dana":
				ChangeCurrentCharacter(11, "Дана");
				break;

			case "Rogataya":
				ChangeCurrentCharacter(6, "Рогатая");
				break;

			default:
				throw new Exception("Incorrect character tag in CompareCharacterTags()");
		}
	}
	private void ChangeCurrentCharacter(int index, string name)
	{
		currentSub.ChangeCharacter(index);
		currentSub.ChangeName(name);

		if (_leftSub == currentSub)
		{
			SaveManager.Instance.SaveLeftCharacter(index, name);
		}
		else if (_rightSub == currentSub)
		{
			SaveManager.Instance.SaveRightCharacter(index, name);
		}
	}

	private void HideSub()
	{
		if (currentSub != null)
		{
			_taskManager.AddTask(currentSub, currentSub.MovingOffTheScreen(), Call);
		}
		_taskManager.AddTask(_background, _background.MovingToMiddlePosition(), Call);
	}

	private void OnDisable()
	{
		OnStep -= RefreshView;
	}

	private IEnumerator ShowVideo(int index)
	{
		MenuButton.interactable = false;
		yield return StartCoroutine(currentSub.MovingOffTheScreen());
		if (index >= 2)
		{
			yield return StartCoroutine(AudioFade());
		}
		yield return StartCoroutine(_background.Fade());
		videoPlayer.clip = SettingsManager.Instance.Video[index];
		videoPlayer.Prepare();
		yield return new WaitUntil(() => videoPlayer.isPrepared);
		videoPlayer.Play();
		yield return new WaitUntil(() => videoPlayer.isPlaying == false);
		videoPlayer.Stop();
		yield return StartCoroutine(_background.UnFade());
		if (index >= 2)
		{
			yield return StartCoroutine(AudioUnFade());
		}
		RefreshView();
		yield break;
	}

	private IEnumerator ShowPhoto(int index)
	{
		MenuButton.interactable = false;
		yield return StartCoroutine(currentSub.MovingOffTheScreen());
		GameObject _photo = Instantiate(SettingsManager.Instance.Photo[index]) as GameObject;
		_photo.transform.SetParent(Maincanvas.transform, false);
		Image imagePhoto = _photo.GetComponent<Image>();
		var Seq = DOTween.Sequence();
		Seq.Append(imagePhoto.DOFade(0.0f, 0.0f));
		Seq.Join(imagePhoto.DOFade(1.0f, 1.0f));
		yield return Seq.WaitForCompletion(true);
		yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
		Seq.Join(imagePhoto.DOFade(0.0f, 1.0f));
		yield return Seq.WaitForCompletion(true);
		Destroy(_photo);
		yield break;
	}
	private IEnumerator ChangeMusic(int x)
	{
		if (audioSource.clip != SettingsManager.Instance.Audio[x])
		{
			SaveManager.Instance.SaveMusic(x);
			if (audioSource.isPlaying)
			{
				yield return StartCoroutine(AudioFade());
			}
			audioSource.clip = SettingsManager.Instance.Audio[x];
			audioSource.Play();
			yield return StartCoroutine(AudioUnFade());
		}
	}

	private IEnumerator AudioFade()
	{
		for (float f = 1.0f; f>=0; f -= 0.01f)
		{
			audioSource.volume = f;
			yield return null;
		}
			audioSource.Pause();
	}

	private IEnumerator AudioUnFade()
	{
		audioSource.UnPause();
		for (float f = 0f; f <= 1; f += 0.01f)
		{
			audioSource.volume = f;
			yield return null;
		}
	}
}