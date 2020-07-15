
testdi #mainSub
->testchoise



=== testchoise ===
* {not test1} [test1]
    test1 #mainSub
    -> testchoise
* {not test2} [test2]
    test2 #mainSub
    -> testchoise
* [test3]
    test3 #mainSub
    ->END
+   ->END


=== test1 ===
test1 #mainSub
->testchoise

=== test2 ===
test2 #mainSub
->testchoise