# インスタンスを作ろう！
C#の大切な考え方として、クラスとインスタンスというものがある。
クラスっていうのはざっくりと人間という分類
インスタンスは実際の人物みたいなイメージ
インスタンスを作ってあげないとその物自体に干渉はできない
A君にいたずらはできないけど人間と分類されてるもの自体にいたずらはできないよねって感じです
それぞれ定義の仕方は以下

```
public class Human
{
    // コンストラクタ
    // ここで初期値を設定してあげる。人間だと、だれ？ってことを識別させてあげるのがよいかなと
    public Human(string name)
    {
        this.Name = name;
    }

    // 名前
    public string Name { get; }
}

// 別ファイルのMain関数
public static Main()
{
    // C#でのインスタンス宣言はnew キーワードを使う
    var A君 = new Human("A君");
}
```

# Listを使いこなそう
配列を便利に扱えるクラスとして、Listクラスというものが存在する。
Cだと配列の大きさなどを宣言時に決める必要があるが、Listには特にそんなことをする必要はなく追加削除を容易に使える
使い方は簡単以下のようにインスタンスを作成するだけ！
```
var list = new List<string>{ "hoge1" };

// 要素にhoge2を足す
list.Add("hoge2");

// 要素からhoge1を消す
list.Remove("hoge1");
```

多次元配列にする場合はListにListを突っ込むのもあり
```
var list = new List<List<string>> { new List<string>{"hoge1"} };
```

Listはプリミティブな型でなく、クラスも格納できる
```
public class Hoge
{
    .....
}

public static Main()
{
    var list = new List<Hoge>{ new Hoge() };
}
```

# Linqを使いこなそう
参考:http://d.hatena.ne.jp/chiheisen/20111031/1320068429
Linqはとっても便利！
しかし、初めてLinqを使うとき？？？？ってなっちゃう。
foreachのチョー便利版と考えたらいいです。

例
例えば、身長170センチ以上の人だけおいで！っていう場合
foreachで書くのと、Linqで書くのではこうも違う

```
// 前提となるHumanクラス
public class Human
{
    // コンストラクタ
    public Human(string name, int height)
    {
        this.Name = name;
        this.Height = height;
    }

    // 名前
    public string Name { get; }

    // 身長
    public int Height { get; }
}
```

// foreachで書く場合
```
// Human100人をListに詰めてると思ってください。
var humanList = new List<Human> .......

// 詰め込むよう
var overHumanList = new List<Human>();

foreach (var human in humanList)
{
    if(human.Height >= 170)
    {
        overHumanList.Add(human);
    }
}
```

// Linqで書く場合
```
using System.Linq;

// Human100人をListに詰めてると思ってください。
var humanList = new List<Human> .......

// 詰め込むよう
var overHumanList = humanList.Where(human => human.Height >= 170);
```

シンプルなことは明らか。
参考に示してるサイトにLinq一覧が載っているので性質はよく理解しておこう