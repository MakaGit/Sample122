VAR number_of_blue_answers = 0
VAR number_of_red_answers = 0
VAR answer_flag = 0

->Chapter5
== Chapter5 ==

Если вы еще не устали… #mainSub
Мы устали. #leftSub
...то продолжаем! #mainSub
Вопрос первый! #mainSub
->Question1

=== Question1 ===
-Кто это делает, тот сразу продает, кто это покупает, тому тоже не нужно, а кто этим пользуется, об этом не знает. #mainSub
* [Яд.]
    ~number_of_red_answers++
    Ну, близко. Это гроб. #mainSub
    ->Question2
    
* [Гроб.]
    ~number_of_blue_answers++
    Верно! #mainSub
    ->Question2

=== Question2 ===
-Вопрос второй! Банан - это овощ, ягода или трава? #mainSub
* [Овощ.]
    ~number_of_red_answers++
    Нет, это трава. #mainSub
    ->ChoiseNode

* [Ягода.]
    ~number_of_red_answers++
    Нет, это трава. #mainSub
    ->ChoiseNode
    
* [Трава.]
    ~number_of_blue_answers++
    Да, это трава. #mainSub
    ->ChoiseNode
    
=== ChoiseNode ===    
Отлично! Теперь время результатов! #mainSub
{answer_flag > 0:
    А может лучше мы тебя проспрашиваем наконец? #leftSub
    О чем, например? #mainSub
    Мы ничего толком не понимаем. Ни что здесь происходит, ни кто мы такие, ничего вообще. #leftSub
    И ты даже не стараешься объяснить. Только кидаешь в нас случайные факты! #leftSub
    Кто, например, такая Мария? #leftSub
    Эх. #mainSub
    Я бы вам рассказала, но… #mainSub
    Слишком долгая выйдет история. А нам несколько раз еще прокручивать этот диалог. #mainSub
    И вы все равно забудете. #mainSub
    ->Chapter5end
}    
 {number_of_red_answers > number_of_blue_answers:
    Мне кажется, вы даже не старались пройти этот тест. Ну и ладно. #mainSub
    ->Chapter5end
- else:
    У нас тест пройден. Ура! Сейчас обнулим вам память и пройдем по новой. #mainSub
    ->Chapter5end
}

=== Chapter5end ===
Как бы то ни было, на сегодня закончим. Отличная была разминка! #mainSub

-> END