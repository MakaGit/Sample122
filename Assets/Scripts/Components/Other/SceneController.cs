using UnityEngine;
using UnityEngine.UI;
using System;
using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SceneController : MonoBehaviour
{
	[SerializeField] private TextAsset inkJSONAsset = null;
	public Story story;

	[SerializeField] private Canvas canvas = null;

	//[SerializeField] private Text textPrefab = null;
	[SerializeField] private Button buttonPrefab = null;

	[SerializeField] private Subject _mainSub;
	[SerializeField] private Subject _leftSub;
	[SerializeField] private Subject _rightSub;

	private Subject currentSub = null;

	public static event Action<Story> OnCreateStory;

	public Action OnStep;
	public Action Call;

	private TaskManager _taskManager = new TaskManager();


	void Awake()
	{
		OnStep += RefreshView;
		currentSub = null;
		StartStory();

	}

	void StartStory()
	{
		story = new Story(inkJSONAsset.text);
		if (OnCreateStory != null) OnCreateStory(story);
		RefreshView();
	}



	void RefreshView()
	{
		RemoveChildren();

		if (story.canContinue)
		{
			string text = story.Continue();
			List<string> tagsList = story.currentTags;
			foreach (string tags in tagsList)
			{
				switch (tags)
				{
					case "mainSub":
						Debug.Log("mainSub tag");

						if (currentSub == _mainSub)
						{
							_taskManager.AddTask(currentSub, currentSub.TextStep(text), OnStep);
						}
						else if (currentSub == null)
						{
							currentSub = _mainSub;
							_taskManager.AddTask(currentSub, currentSub.MovingToTheScreen(text), OnStep);
						}
						else
						{
							_taskManager.AddTask(currentSub, currentSub.MovingOffTheScreen(), Call);
							currentSub = _mainSub;
							_taskManager.AddTask(_mainSub, _mainSub.MovingToTheScreen(text), OnStep);
						}
						break;

					case "leftSub":
						Debug.Log("leftSub tag");

						if (currentSub == _leftSub)
						{
							_taskManager.AddTask(currentSub, currentSub.TextStep(text), OnStep);
						}
						else if (currentSub == null)
						{
							currentSub = _leftSub;
							_taskManager.AddTask(currentSub, currentSub.MovingToTheScreen(text), Call);
						}
						else
						{
							_taskManager.AddTask(currentSub, currentSub.MovingOffTheScreen(), OnStep);
							currentSub = _leftSub;
							_taskManager.AddTask(_leftSub, _leftSub.MovingToTheScreen(text), OnStep);
						}
						break;

					case "rightSub":
						Debug.Log("rightSub tag");

						if (currentSub == _rightSub)
						{
							_taskManager.AddTask(currentSub, currentSub.TextStep(text), OnStep);
						}
						else if (currentSub == null)
						{
							currentSub = _rightSub;
							_taskManager.AddTask(currentSub, currentSub.MovingToTheScreen(text), OnStep);
						}
						else
						{
							_taskManager.AddTask(currentSub, currentSub.MovingOffTheScreen(), Call);
							currentSub = _rightSub;
							_taskManager.AddTask(_rightSub, _rightSub.MovingToTheScreen(text), OnStep);
						}
						break;

					default:
						Debug.Log("incorrect tag");
						break;
				}
			}
		}
		else if (story.currentChoices.Count > 0)
		{
			//StartCoroutine(_leftSub.EmptyMovingToTheScreen());

			for (int i = 0; i < story.currentChoices.Count; i++)
			{
				Choice choice = story.currentChoices[i];
				Button button = CreateChoiceView(choice.text/*.Trim()*/);
				// Tell the button what to do when we press it
				button.onClick.AddListener(delegate
				{
					OnClickChoiceButton(choice);
				});
			}
		}
		else
		{
			//Button choice = CreateChoiceView("End of story.\nRestart?");
			//choice.onClick.AddListener(delegate
			//{
			//	StartStory();
			//});
			UserInterfaceManager.Instance.EnablePanel(UIPanelType.ChapterCompletePanel);
		}

	}

	// When we click the choice button, tell the story to choose that choice!
	void OnClickChoiceButton(Choice choice)
	{
		story.ChooseChoiceIndex(choice.index);
		//StartCoroutine(_leftSub.MovingOffTheScreen());
		RefreshView();
	}

	// Creates a button showing the choice text
	Button CreateChoiceView(string text)
	{
		// Creates the button from a prefab
		Button choice = Instantiate(buttonPrefab) as Button;
		choice.transform.SetParent(canvas.transform, false);

		// Gets the text from the button prefab
		TMP_Text choiceText = choice.GetComponentInChildren<TMP_Text>();
		choiceText.text = text;

		// Make the button expand to fit the text
		//HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
		//layoutGroup.childForceExpandHeight = false;

		return choice;
	}
	void RemoveChildren()
	{
		int childCount = canvas.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i)
		{
			GameObject.Destroy(canvas.transform.GetChild(i).gameObject);
		}
	}
}