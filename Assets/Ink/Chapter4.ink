VAR number_of_blue_answers = 0
VAR number_of_red_answers = 0
VAR answer_flag = 0

->Chapter4
== Chapter4 ==

И снова здравствуйте! #mainSub
Опять она. #rightSub
Продолжим наш тест. #mainSub
Нам нужно посмотреть, как Андрей делает дерево диалогов. #mainSub
Я все еще не понял, что значит… #leftSub
Вопрос первый!#mainSub
->Question1

=== Question1 ===
Сколько здесь находится человек? #mainSub
* [Эм… Трое?]
    ~number_of_blue_answers++
    Верно! #mainSub
    ->Question2
    
* [Двое?]
    ~number_of_red_answers++
    То есть меня ты за человека даже не считаешь, да? #mainSub
    Нас трое! #mainSub
    ->Question2

=== Question2 ===
Вопрос второй! Какого цвета небо? #mainSub
* [ Голубое.]
    ~number_of_blue_answers++
    Верно. Хотя тут скорее синее... #mainSub
    ->Question3

* [Зеленое.]
    ~number_of_red_answers++
    Не язви мне, пожалуйста, это обидно. #mainSub
    Не я же вас сюда засунула. #mainSub
    ->Question3
    
=== Question3 ===
Вопрос третий! Назовите квадратный корень из 32,041. #mainSub
* [189]
    ~number_of_red_answers++
    Нет, 179. #mainSub
    ->Question4
    
* [187]
    ~number_of_red_answers++
    Нет, 179. #mainSub
    ->Question4
    
* [179]
    ~number_of_blue_answers++
    Верно! #mainSub
    ->Question4
    
* [169]
    ~number_of_red_answers++
    Нет, 179. #mainSub
    ->Question4
    
* [164]
    ~number_of_red_answers++
    Нет, 179. #mainSub
    ->Question4
    
* [154]
    ~number_of_red_answers++
    Нет, 179. #mainSub
    ->Question4
    
* [Я гуманитарий.]
    ~number_of_red_answers++
    Ты - простынь. Ответ 179. #mainSub
    ->Question4
    
=== Question4 ===
* [Мне не нравится в это играть.]
    Но тут больше нечего делать. Только строить дерево диалогов. #mainSub
    ->Question5
    
* [Что будет, если мы не пройдем тест?]
    ~answer_flag++
    В конце пятой главы будет кусок контента, который предназначен для такого случая. #mainSub
    Ой, или ты боишься? #mainSub
    Не стоит. С вами ничего плохого не сделают. Сейчас мы просто репетируем перед большой постановкой. #mainSub
    Что Андрей, что Елена, что Мария, да и все остальные сейчас готовятся к вашей истории, а мы просто весело проводим время. #mainSub
    ->Question5

=== Question5 ===
Вопрос четвертый! #mainSub
Это длиннее всего на свете — и короче. Быстрее всего — и медленнее. Самое дробное — и самое неразрывное. Это меньше всего ценят, но больше всего сожалеют при отсутствии. Без этого ничего не может быть сделано. #mainSub
Что это? #mainSub
* [Честь?]
    ~number_of_red_answers++
    Нет, время. #mainSub
    ->Chapter4end
    
* [Правда?]
    ~number_of_red_answers++
    Нет, Время. #mainSub
    ->Chapter4end
    
* [Время?]
    ~number_of_blue_answers++
    Да, оно. #mainSub
    ->Chapter4end
    
=== Chapter4end ===    
Итак, результаты. #mainSub
{number_of_red_answers > number_of_blue_answers:
    Вы лажаете, ребятки. #mainSub
- else:
    Пока что больше правильных ответов. Вы молодцы!. #mainSub
}

Отлично. Остался еще один эксперимент. #mainSub

-> END