cowsay
===

.NET package that emulates the classic linux tool [cowsay](http://en.wikipedia.org/wiki/Cowsay).


#### Usage
``` bash
> .\cowsay gossip girl xox
 _________________
< gossip girl xox >
 -----------------
       \   ^__^
        \  (oo)\_______
           (__)\       )\/\
               ||----w |
               ||     ||
```


#### Options

The following are flags you can pass into the arguments along with the string content to display to modify the output cow.

| Argument Flag | Description |
|---------------|-------------|
| -d            | "[Borg](http://en.wikipedia.org/wiki/Borg_(Star_Trek)) mode", uses == in place of oo for the cow′s eyes. |
| -d            | "Dead", uses XX, plus a descending U to represent an extruded tongue. |
| -g            | "Greedy", uses $$. |
| -p            | "Paranoid", uses @@. |
| -s            | "Stoned", uses ** to represent [bloodshot eyes](http://en.wikipedia.org/wiki/Red_eye_(medicine)), plus a descending U to represent an extruded tongue. |
| -t            | "Tired", uses --. |
| -w            | "Wired", uses OO. |
| -y            | "Youthful", uses .. to represent smaller eyes. |


#### TODO

* Add other options to bring it up to the same level as the latest cowsay.
* Add docs on installing it via nuget and adding it to PATH with DNX. Need to look into this.