/*
#mainSud - Слова автора
#rightSub - Слова второстепенного персонажа
#leftSub - Слова ГГ
*/

VAR Virus_points = 0
VAR Cure_points = 0

->Chapter1

=== Chapter1 ===
->Node_1

=== Node_1 ===
/*
Локация: церковь (горящая)
Дана - слева
Рогатая - справа
*/

...#background_Church #music_1
Вас окружает огонь. Языки пламени охватили стены. Деревянные балки опасно трещат. #mainSub
...#leftSub #character_Dana
Впереди, за стеной пламени, вы различаете смутные очертания человеческих фигур. Люди  пойманы в огненную ловушку #mainSub
->Choise_Ia

=== Choise_Ia ===
* [Попытаться помочь людям]
    ~Cure_points++
    ->Node_2

* [Попытаться выбраться самой]//Ia2
    ~Virus_points++
    ->Node_2

=== Node_2 ===
Вы медленно движетесь сквозь алый ад. Дым разъедает глаза и заползает в легкие. Вы сгибаетесь пополам от кашля. Голова идет кругом. Вы понимаете, что вот-вот потеряете сознание. #mainSub
->Choise_Ib

=== Choise_Ib ===
* [Оторвать кусок от платья и использовать как повязку на лицо]//Ib1
    Сухая ткань почти не задерживает дым. Очередной приступ кашля заставляет вас упасть на колени. Из-за дыма вы почти ослепли. Краем глаза вы замечаете фигуру, приближающуюся к вам прямо сквозь пламя. #mainSub
    ... #video_1
    Чья-то рука крепко хватает вас за запястье. #mainSub
    //Голос Дана…
    ->Node_3

* [Опуститься на пол и ползти]//Ib2
    Вы падаете на пол. Здесь, у самых досок,  вам удается сделать глоток свежего воздуха. Сознание немного проясняется. Краем глаза вы замечаете фигуру, приближающуюся к вам прямо сквозь пламя. #mainSub
    ... #video_1
    ... #rightSub #character_Rogataya
    Дым вновь заполняет легкие. Вы задыхаетесь. Чья-то рука крепко хватает вас за запястье. #mainSub
    //Голос Дана…
    ->Node_3

=== Node_3 ===
/*
Локация: палата 122 (ночь)
Дана - слева
Аглая - справа
*/

...#background_DanaRoomNight #achievement_2 #music_2
Вы открываете глаза и несколько секунд не можете понять, где находитесь. #mainSub
Дана? Ты в порядке? #rightSub #character_Aglaya
Я… да. Просто плохой сон. #leftSub #character_Dana
//Аглая (довольная)
Я так и подумала. Побыть с тобой? #rightSub
Вы смотрите на улыбающуюся подругу. Кошмар отпускает вас и безумно колотящееся сердце начинает биться спокойнее. В какой-то момент из-за левого плеча Аглаи выглядывает… #mainSub
... #rightSub #character_Rogataya
Ох! #leftSub
Что случилось? #rightSub #character_Aglaya
->Choise_Ic

=== Choise_Ic ===
* [Рассказать]//Ic1
    ~Virus_points++
    Это странно, но… Я только что видела женщину из моего сна. Я схожу с ума? #leftSub
    Это все теснота. Мы слишком редко бываем на воздухе. Одна хорошая прогулка - и все твои кошмары как ветром сдует. #rightSub
    Было бы круто… Видит рогатую женщину - звучит, как диагноз #leftSub
    Ты видела Рогатую? #rightSub
    Ну… мне снилась женщина с рогами на голове… большими такими, как у барана. И сейчас тоже... #leftSub
    Ух ты! Это же Рогатая #rightSub
    О чем ты? #leftSub
    Матушка говорит, что Рогатая - добрый дух Пустоши. Увидеть ее - добрый знак! #rightSub
    Папа вряд ли с тобой согласится. Лучше ему не знать об этом. Уже поздно - давай спать. #leftSub
    ->Node_4

* [Умолчать]//Ic2
    ~Cure_points++
    Ничего, просто… мерещится всякое. Уже поздно - давай лучше спать. #leftSub
    Хочешь, побуду с тобой, пока ты не заснешь? #rightSub
    
    ** [Мне лучше спится одной]//Ic1.1
        ~Cure_points++
        Слушая мерное дыхание Аглаи, вы погружаетесь в сон #mainSub
        ->Node_4
        
    ** [Я буду рада]//Ic1.2
        ~Virus_points++
        Слушая мерное дыхание Аглаи, вы погружаетесь в сон #mainSub
        ->Node_4
        
=== Node_4 ===
/*
Локация: Ритуальный костер (ночь)
Сафо - слева
Все остальные - справа
*/

...#background_Campfire #music_0 #achievement_2
Высокий костер освещает окрестности, отбрасывает яркий блики на лица собравшихся вокруг людей.  Вокруг огня танцуют девушки в ритуальных одеждах. #mainSub
...#video_0
Вы кутаете лицо в шарф, хотя в этом нет особой необходимости: зачарованные танцем девушек, соплеменники впали в транс и не замечают ничего вокруг. #mainSub
... #leftSub #character_SafoLeft
Вы внимательным взглядом окидываете толпу. Агапа стоит чуть поодаль от основного скопления людей и даже не смотрит в сторону танцовщиц. Она явно погружена в свои мысли. Вы быстро пробираетесь к ней. #mainSub
... #rightSub #character_AgapaRight
->Choise_Id

=== Choise_Id
Агапа стоит чуть поодаль от основного скопления людей и даже не смотрит в сторону танцовщиц. Она явно погружена в свои мысли. Вы быстро пробираетесь к ней. #refresh
* [Ткнуть девушку в бок]//Id1
    Ай! #rightSub
    Девушка мигом выныривает из размышлений и с поразительный быстротой выхватывает из-за пояса кинжал. #mainSub
    Какого… Матушка? #rightSub
    Чай спишь на ходу, Агапушка? А чуть что - сразу за нож... #leftSub
    ->Node_5

* [Поздороваться]//Id2
    Агапа поднимает на вас глаза, но смотрит сквозь, словно не замечает. #mainSub
    Чай спишь на ходу? #leftSub
    ->Node_5
    
=== Node_5 ===
Прости, Матушка, я тебя не заметила… #rightSub #achievement_1
Несколько секунд вы вглядываетесь в бледное лицо девушки, раздумывая, не слишком ли велика для нее миссия, которую вы собираетесь на нее возложить. Впрочем, думаете вы, это не вам решать. #mainSub
->Choise_Ie

=== Choise_Ie ===
* [Отчего ты не веселишься с остальными?]//Ie1
    Отчего ты не веселишься с остальными? Завтра вам предстоит большое дело вместе… #leftSub
    Мне не до веселья, Матушка, сама знаешь #rightSub
    Всему свое время - и скорби, и веселью #leftSub
    А ты отчего не веселишься? Ты же придумала эти танцы #rightSub
    Вы тушуетесь от наглости девушки и сперва хотите огреть ее клюкой, но, глядя на ее изможденное лицо и лихорадочно блестящие глаза, разражаетесь хриплым смехом #mainSub
    Тебе палец в рот не клади - откусишь по локоть! #leftSub
    Вы примирительно гладите девушку по руке #mainSub
    ->Node_6

* [О чем ты задумалась так крепко?]//Ie2
    О чем ты задумалась так крепко? #leftSub
    Агапа раздраженно трясет головой и отворачивается - ей не хочется отвечать. Но под вашим пристальным взглядом она, все же, не выдерживает #mainSub
    Это уже третья лаборатория, Матушка! Третья! Ее нигде нет… Что, если твари увезли ее в город? #rightSub
    Верь мне, милая, Аглая все еще здесь. Пустошь чует ее. Я чую... #leftSub
    Я верю тебе… Но чем больше мы тратим время на… это #rightSub
    Агапа кивает головой в сторону костра #mainSub
    ...тем меньше времени остается у Аглаи. Как я успею найти ее? Лучше бы я одна ходила… #rightSub
    Ты - воин. каких поискать, Агапушка. Но ты - одна, против городских… Их там немало. #leftSub
    Они лентяи и трусы. Я бы справилась! #rightSub
    Вы молча качаете головой. Безумие все больше овладевает Агапой - вы чувствуете  ее кислый запах. #mainSub
    Оно может сыграть как вам на руку, так и против вас. Подбирать слова нужно очень осторожно. Вы примирительно гладите девушку по руке #mainSub
    ->Node_6
    
=== Node_6 ===
... #video_2
Ритм, который отбивают босые ступни танцовщиц, ускоряется. Девушки кружатся все быстрее. Отблески пламени сияют на голой коже так, что кажется, будто танцовщицы вот-вот вспыхнут. #mainSub
->Choise_If

=== Choise_If ===
* [Поговорить о Пустоши]//If1
    ~Cure_points++
    К чему все это, Агапа? Почему мы не оставим их в покое? #leftSub #achievement_3
    Девушка бросает на вас яростный взгляд и сжимает кулаки так, что белеют костяшки пальцев. #mainSub
    Они крадут наших детей - а ты предлагаешь просто смириться?! Что, зарыться в норы и молится, чтобы они нас не тронули? Да что с тобой сегодня, Матушка?! #rightSub
    Я такого не говорила #leftSub
    Тогда говори прямо! Я устала от твоих загадок! Неужели ты не понимаешь, что сейчас не время! #rightSub
    Вы долго всматриваетесь в лицо Агапы, и она не отводит взгляд. Внутри девушки бурлит такая ярость, что вы почти ощущаете ее кожей. #mainSub
    Ритуальный танец почти достиг апогея, скоро случится то, ради чего костер и был разожжен. #mainSub
    Чтобы я не сказала, Агапушка, для тебя звучит загадкой. Ты не знаешь себя. Но ты знаешь Пустошь. Ты - праведница. #leftSub
    ->Node_7

* [Поговорить о семье]//If2
    ~Virus_points++
    Посмотри туда #leftSub #achievement_4
    Вы указываете пальцем в толпу возле костра, где виднеется неподвижная фигура альбиноса. Белоснежные волосы в свете костра кажутся ярко-оранжевыми. #mainSub
    ... #rightSub #character_KarpRight
    Почувствовав ваш взгляд, Карп оборачивается. Несколько мгновений он выглядит озадаченным, но, заметив рядом с вами Агапу, улыбается, подмигивает девушке и снова отворачивается к костру. #mainSub
    Агапа презрительно фыркает #mainSub
    Это Карп, раздолбай. Его белая рожа - отличная мишень. Или что ты хочешь про него услышать? #rightSub #character_AgapaRight
    Его родители погибли от мора... #leftSub
    Как почти у всех здесь! #rightSub
    ...ему было всего пять. Если бы не старший брат - он бы не выжил. Они были неразлучны, как ты с Аглаей. Пока брата не убили людоеды с севера. #leftSub
    Агапа смотрит на вас чуть приоткрыв рот, словно хочет что-то сказать, но не решается. #mainSub
    Брата съели, а Карпа держали в подвале - про запас. Я на руках его оттуда вынесла. От страха и скорби мальчишка не мог пошевелиться. А заговорил только через год… #leftSub
    Я не знала… #rightSub
    Вы вздыхаете и плотнее кутаетесь в шерстяной плоток. Несмотря на теплый ночной воздух, вас знобит. Старость берет свое. #mainSub
    Само собой не знала! Из всей деревни теперь знаем Карп, я и ты. #leftSub
    Зачем ты рассказала мне? #rightSub
    Ты так глубоко погрузилась в скорбь, что забыла - мы все здесь кого-то потеряли. Вся Пустошь наполнена болью, кровью и костями. Но у тебя есть надежда, которой никогда не было у Карпа. #leftSub
    Агапа долго молчит. Ритуальный танец почти достиг апогея, скоро случится то, ради чего костер и был разожжен. #mainSub
    Ты права, Матушка. У меня есть надежда… #rightSub
    ->Node_7
    
=== Node_7 ===
Танцовщицы движутся так быстро, что сами становятся похожи на сумасшедшие языки пламени, взмывающие к ночному небу. #mainSub
Смотрители подбрасывают ветки в огонь и он разгорается с громким треском, разбрасывая вокруг снопы искр. #mainSub
Вы следите за танцем, но краем глаза замечаете движение в толпе - Карп пробирается прочь от костра. #mainSub
... #video_3
Когда раздается душераздирающий женский крик и очнувшиеся от оцепенения люди начинают восторженно галдеть, Карп лишь вздрагивает и начинает еще активнее пробиваться прочь из толпы. #mainSub
Агапа и вы натягиваете шарфы на лица, но резкий запах горелого мяса все равно пробирается в ноздри. #mainSub
Вы берете Агапу за руку и уводите от костра. На рассвете золой от жертвенного костра удобрят поля, а те дадут щедрые всходы. Таков закон. Пустошь жестока. #mainSub
Когда вы с Агапой оказываетесь достаточно далеко от остальных, вы снова заговариваете. #mainSub
Почему мы живем здесь, под стенами города и подвергаем опасности наших детей? Почему не уйдем глубже в Пустошь, которой принадлежим? Разве это не странно? #leftSub
Да ты же сама запретила уходить! #rightSub
Мы слишком долго были привязаны к этому месту… #leftSub
Вы поднимаете глаза к небу, полной грудью вдыхаете свежий ночной воздух. #mainSub
Агапа, то место, куда вы идете завтра… Это не просто лаборатория #leftSub
->Node_8

=== Node_8 ===
/*
Локация: Палата 122 (день)
Дана - слева
Все остальные - справа
*/

...#background_DanaRoomDay #music_2
Сквозь сон до вас доносится неясный гул. Просыпаться ужасно не хочется и вы натягиваете одеяло на голову. В этот момент раздается пронзительный крик. Вы вскакиваете с кровати #mainSub
Что?.. Что происходит? Аглая? #leftSub #character_Dana
Посреди палаты стоит Санитар и крепко сжимает руку Аглаи. Подруга выглядит взъерошенной, как будто только что проснулась, но тем не менее яростно брыкается. #mainSub
Пусти! Пусти я сказала, чума тебя задери! Дана! #rightSub #character_Aglaya
Дана, успокой свою подругу! Доктор хочет ее осмотреть #rightSub #character_Sanitar
->Choise_Ih

=== Choise_Ih ===
* [Поддержать Санитара]//Ih1
    ~Virus_points++
    Аглая, успокойся. Ты что, маленькая, что иголок боишься? Папа просто тебя осмотрит #leftSub #achievement_5
    Ага, конечно! Почему тогда я одна иду? Мы же всегда вместе ходили на осмотры #rightSub #character_Aglaya
    Может, он хочет узнать, как тебе со мной живется? Чтобы ты не боялась говорить про меня всякие гадости. Аглая, доверься мне, бояться нечего. #leftSub
    Ну ладно… уж кому-кому, а тебе я точно могу верить #rightSub #character_Aglaya
    Санитар выводит Аглаю из палаты. Ваши внутренности сдавливает плохое предчувствие, но когда подруга оборачивается на вас, вы выдавливаете из себя улыбку. #mainSub
    Дверь захлопывается, оставляя вас наедине с тревожными мыслями. #mainSub
    ->Node_9

* [Поддержать Аглаю]//Ih2
    ~Cure_points++
    С чего бы это? Я пойду с ней #leftSub
    Дана, ну только ты не начинай, а? Ты же знаешь: Док отдает приказы - я выполняю. Он сказал привести сто тридцать третью - значит, я ее приведу. #rightSub #character_Sanitar
    Аглая! Ее зовут Аглая! #leftSub
    Хватит! А ну пойдем! #rightSub #character_Sanitar
    Нет! #rightSub #character_Aglaya
    Санитар тянет Аглаю к двери. Та отчаянно пинает его, но крепкий мужчина, кажется, даже не замечает ее сопротивления #mainSub
    
    ** [Пнуть санитара]//Ih2.1.1
        Вы подскакиваете к Санитару и ярстно пинаете его в коленную чашечку. От боли и удивления мужчина охает и разжимает хватку. Аглая тут же вырывается и бежит к открытой двери. #mainSub #achievement_6
        Санитар рычит от ярости, отшвыривает вас в сторону с такой силой, что вы отлетаете к стене. Несколько мгновений вы не можете даже вдохнуть. #mainSub
        Перед глазами пляшут искры, но вы все равно видите, как Санитар оглушает Аглаю электрошоковой дубинкой, взваливает на плечо безвольное тело и выходит из палаты #mainSub
            ->Node_9
        
    ** [Смириться]//Ih2.1.2
        Внутри вас бурлит ярость, но вы хорошо понимаете, что бессильны против крепкого, рослого мужчины. Санитар вытаскивает Аглаю из палаты. #mainSub #achievement_7
        Подруга оборачивается на вас в поисках поддержки, но вы лишь стыдливо отводите глаза. Дверь захлопывается, оставляя вас наедине с горькими мыслями. #mainSub
        ->Node_9


=== Node_9 ===
/*
Локация: дом Карпа (день)
Карп - слева
Сафо - справа
*/

...#background_HouseKarp #music_1
Вы еще раз перепроверили обмундирование: пистолет, две обоймы, охотничий нож, кусок веревки, три метательных ножа, фляга с водой. Негусто, но это все, что у вас есть. #mainSub
Волнуешься? #rightSub #character_Safo
Матушка? Как ты ходишь так тихо? #leftSub #character_Karp
Нехитрое дело - незаметно подобраться к тому, кто в думы тягостные погружен. Так как: волнуешься или нет? #rightSub
->Choise_Ii

=== Choise_Ii ===
* [Да]//Ii1
    Признаться… да. Я не уверен, что все это… правильно. #leftSub
    Молодец, коль так. Только дурак ничего не боится, да ни в чем не сомневается. #rightSub
    ->Node_10

* [Нет]//Ii2
    Нет, Матушка Сафо. Ты говоришь с Пустошью. Ты слышишь ее голос. И если ты говоришь что-то сделать - я это делаю. Без колебаний. #leftSub
    Ну и дурак, коли так. Только дурак ничего не боится, да ни в чем не сомневается. #rightSub #achievement_8
    ->Node_10
    
=== Node_10 ===
Ты же сама дала нам это задание! #leftSub
Ага, все так. Вот только что может знать старуха, которая уже десять лет дальше нашей деревни-то и не ходила?. #rightSub
Матушка Сафо опирается на клюку и лукаво смотрит на вас. Шаманка никогда не говорит прямо - и никогда не бросает слов на ветер. Она явно испытывает вас. Но суть этой проверки вам не ясна. #mainSub
->Choise_Ij

=== Choise_Ij ===
* [Усомниться в здравомыслии Матушки]//Ij1
    Ну знаешь… То ты говоришь одно, то другое… Мы рискуем жизнями, а ты сама не веришь в свои слова? Во что же тогда верить мне? #leftSub
    ->Node_11

* [Убедить, что Матушке виднее]//Ij2
    Ты  говоришь с Пустошью. Ты говоришь с Рогатой. Мои сомнения - просто слабость. Я доверяю твоим решениям #leftSub
    ->Node_11

=== Node_11 ===
С неожиданной ловкостью Матушка Сафо подскакивает к вам, хватает клюкой за шею, заставляя согнуться. Ее испещренное морщинами лицо оказывается совсем рядом с вашим #mainSub
Ты сомневаешься  во мне, Карп. Ты сомневаешься в Рогатой. #rightSub
На секунду дыхание перехватывает. Глаза старухи, кажется, сверлят дыры в вашем лице. #mainSub
И поэтому, Карп, я доверяю тебе, больше, чем Агапе. Агапа слепа - ее ослепила жажда  мести. Агапа глуха - ее оглушила скорбь. Но у Агапы громкий голос - за нее говорит ярость. А ты, Карп, зряч и нем. Ты - еретик. #rightSub
По спине бегут ледяные мурашки. Вы смотрите на Матушку в оцепенении, ожидая, что будет дальше #mainSub
Я не знаю, что или кто вас там ждет. Пообещай мне, что будешь принимать решения сам - своей головой. Пообещай мне, что будешь верить только себе. Не Агапе. И даже не Рогатой. Только себе #rightSub
->Choise_Ik

=== Choise_Ik ===
* [Обещаю]//Ik1
    ~Virus_points++
    Обещаю… #leftSub
    Старуха довольно улыбается, хлопает вас по плечу и выходит из дома #mainSub
    Боюсь, Агапе будет сложно это объяснить #leftSub
    ->Node_12

* [Не могу обещать]//Ik2
    ~Cure_points++
    Вы напряженно всматриваетесь в лицо старухи, пытаясь угадать правильный ответ. Но полубезумная улыбка и рассеянный взгляд Матушки лишь сбивают вас с толку. #mainSub
    Голос Рогатой - единственный истинный голос в Пустоши. Ее голос - мой голос. Ее желания - мои желания. #leftSub
    Повисает тяжелая пауза. Матушка Сафо долго буравит вас взглядом, словно хочет что-то сказать, но не находит правильных слов. Наконец старуха вздыхает. #mainSub
    Агапе повезло с тобой, Карп #rightSub
    ->Node_12

=== Node_12 ===
/*
Локация: Палата 122 (день)
Дана - слева
Все остальные - справа
*/

...#background_DanaRoomDay #achievement_9 #music_2
С тех пор, как увели Аглаю прошло несколько часов. Ваше беспокойство росло. #mainSub
Несколько раз вы кричали, чтобы вас отвели  к подруге, колотили  в дверь и даже пытались вскрыть замок, но из этого ничего не вышло. Когда вы совсем отчаялись, послышался щелчок замка и дверь открылась. #mainSub
... #leftSub #character_Dana
В палату, серый от усталости, входит ваш отец. #mainSub
Дана… #rightSub #character_Doc
Вы тут же бросаетесь к нему #mainSub
Где она?! Что с Аглаей? #leftSub
Дана, успокойся. Сядь. #rightSub
Отец избегает встречаться с вами взглядом и ваше сердце замирает от дурного предчувствия. #mainSub
-> Choise_Il

=== Choise_Il ===
* [Накричать на отца]//Il1
    Вас охватывает гнев. Вы вскакиваете, яростно сжимая кулаки, и наступаете на отца #mainSub
    Какого черта ты мне врешь?! Где Аглая?! #leftSub
    Аглая заразилась… #rightSub
    Бред! Я видела ее утром - она была здорова! #leftSub
    Вы сверлите отца взглядом, в ответ он скрещивает руки на груди #mainSub
    Мы это уже обсуждали, Дана. Ты не можешь отличить больных от здоровых по одному внешнему виду #rightSub
    Да? Тогда объясни, почему я до сих пор не заразилась, если все эти девочки были больны? #leftSub
    Под вашим яростным напором отец отступает. На лице его появляется растерянное выражение. #mainSub
    
    ** [Продолжить кричать]//Il1.1.1
        ~Cure_points++
        Они никогда не возвращаются! Никогда! Ты хоть кого-нибудь попытался вылечить?! #leftSub
        Отец коротко замахивается и бьет вас по щеке. Голова дергается, а во рту появляется металлический привкус - вы прикусили язык. Вы отступаете и удивленно смотрите на отца #mainSub
        Неблагодарная дрянь… #rightSub
        Отец на каблуках разворачивается и выходит из палаты, хлопнув дверью. #mainSub #achievement_11
        ->END
        
    ** [Успокоиться]//Il1.1.2
        ~Virus_points++
        Отец выглядит усталым и несчастным, и ваш гнев понемногу утихает #mainSub
        Она не вернется, да? #leftSub
        Вы опускаете голову. К глазам подступают слезы. #mainSub
        Мне очень жаль, Дана. Она была хорошей подругой… Вирус никого не щадит. #rightSub
        Слезы катятся по щекам, как вы ни пытаетесь их сдержать. Еще вчера вы с Аглаей планировали побег… Отец осторожно обнимает вас за плечи и усаживает на кровать. Вы всхлипываете #mainSub
        Я не могу так больше… Я не хочу больше тебе помогать… #leftSub
        Отец вздыхает, достает что-то из нагрудного кармана и осторожно кладет вам на колени. Вы смахиваете слезы, чтобы разглядеть. Это фотография #mainSub
        ...#photo_0 #achievement_10
        Этой девочке всего одиннадцать и она заразилась. #rightSub
        Так она… #leftSub
        Вы не решаетесь задать вопрос, но и так знаете ответ. Вирус не щадит никого. #mainSub
        Тысячи людей борются за жизнь каждый день лишь в надежде на то, что мы найдем лекарство. Благодаря этой мысли я могу просыпаться каждое утро. Только благодаря ей. #rightSub
        Отец забирает у вас фотографию, бережно складывает и прячет в карман. #mainSub
        Мне жаль Аглаю. Но я не сдамся. Иначе… #rightSub
        Отец не заканчивает, лишь качает головой. На его лице написана невыразимая тоска. Вы еще не видели его таким. #mainSub
        Пап… #leftSub
        Отец молча встает и выходит из палаты, тихо притворив за собой дверь. Вы остаетесь наедине со своими мыслями. #mainSub #achievement_11
        ->END
        
* [Расспросить спокойно]//Il2
    ~Virus_points++
    Вы вглядываетесь в усталое лицо отца. Вы слишком хорошо знаете это его выражение. Охвативший вас было гнев утихает, уступая зияющей пустоте. #mainSub
    Так… и она тоже? #leftSub
    Мне очень жаль, Дана. #rightSub
    Слезы катятся по щекам, как вы ни пытаетесь их сдержать. Отец осторожно обнимает вас за плечи и усаживает на кровать. Вы всхлипываете #mainSub
    Я не могу так больше… #leftSub
    Тысячи людей борются за жизнь каждый день лишь в надежде на то, что мы найдем лекарство. Благодаря этой мысли я могу просыпаться каждое утро. Только благодаря ей. #rightSub
    Вы не слушаете. Вам осточертели эти речи про спасение мира, про людей, живущих надеждой, про великую миссию. #mainSub
    Вы желаете лишь одного: повернуть время вспять и сбежать с Аглаей из этой проклятой больницы. #mainSub
    Отец видит, что вы не слушаете, рассеянно гладит вас по плечу и выходит из палаты, тихо притворив за собой дверь. Вы остаетесь наедине со своими мыслями. #mainSub #achievement_11
    ->END