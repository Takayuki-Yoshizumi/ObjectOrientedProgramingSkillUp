# インスタンスを作ろう！
C#の大切な考え方として、クラスとインスタンスというものがある。  
クラスっていうのはざっくりと人間という分類  
インスタンスは実際の人物みたいなイメージ  
インスタンスを作ってあげないとその物自体に干渉はできない  
A君にいたずらはできないけど人間と分類されてるもの自体にいたずらはできないよねって感じです  
それぞれ定義の仕方は以下  

```csharp
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
Cだと配列の大きさなどを宣言時に決める必要があるが、Listには特にそんなことをする必要はなく追加削除を容易に使える。  
使い方は簡単以下のようにインスタンスを作成するだけ！  

```csharp
var list = new List<string>{ "hoge1" };

// 要素にhoge2を足す
list.Add("hoge2");

// 要素からhoge1を消す
list.Remove("hoge1");
```

```csharp
// 多次元配列にする場合はListにListを突っ込むのもあり
var list = new List<List<string>> { new List<string>{"hoge1"} };
```

```csharp
// Listはプリミティブな型でなく、クラスも格納できる
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

```csharp
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
```csharp
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
```csharp
using System.Linq;

// Human100人をListに詰めてると思ってください。
var humanList = new List<Human> .......

// 詰め込むよう
var overHumanList = humanList.Where(human => human.Height >= 170);
```

シンプルなことは明らか。  
参考に示してるサイトにLinq一覧が載っているので性質はよく理解しておこう  

# オブジェクト指向の思想
このQiita記事をよく読むとわかりやすい。  
少し長いですが。  
https://qiita.com/tutinoco/items/6952b01e5fc38914ec4e

## カプセル化
カプセル化に関する僕の理解としては、使う人が何も考えずに使える状態にするということです。  
今回の課題の例を出しますと、例えば、三角形の面積の計算をしたい場合。  
三角形を作って使う側のことを考えましょう。  
使うときに常に三角形の面積の計算式を思い浮かべながら面積を計算したくない！とおもいません？(別にそんくらい簡単やんけと思われるかもしれないですが笑)  
カプセル化してないコードとしてるコードではこう違います。(カプセル化してると見せかけて全くしてないコードも載せときます)  

```csharp
// ただの三角形クラスをつくる(オブジェクト指向全くできてない)
public class Triangle
{
    public Triangle(double bottom, double height)
    {
        this.Bottom = bottom;
        this.Height = height;
    }
    
    public double Bottom { get; }
    public double Height { get; }
}

// 使う側
public static void Main()
{
    var triangle = new Triangle(3, 4);
    
    // 面積計算するとき。毎回計算するのめんどくせー
    var area = triangle.Bottom * triangle.Height / 2;
}
```

```csharp
// オブジェクト指向ができてると見せかけてできていないクラス設計
public class Triangle
{
    public double ClacArea(double bottom, double height)
    {
        return bottom * height / 2;
    }
}

// 使う側
public static void Main()
{
    var triangle = new Triangle();

    // 底辺と高さなんて、インスタンスごとに変わることがないのに、毎回入力するのめんどくせー。
    var area = triangle.CalcArea(3, 4);
}
```

```csharp
// オブジェクト指向ができてるクラス設計
public class Triangle
{
    public Triangle(double bottom, double height)
    {
        this.Bottom = bottom;
        this.Height = height;
    }
    
    public double Bottom { get; }
    public double Height { get; }
    
    public double ClacArea()
    {
        return this.Bottom * this.Height / 2;
    }
}

// 使う側
public static void Main()
{
    var triangle = new Triangle(3, 4);

    // Triangleクラスの内部だけで知っとけばいい情報はTriangleクラスに押し込んだ。使う人は楽ちん。
    var area = triangle.CalcArea();
}
```

## 継承、ポリモーフィズム
継承とポリモーフィズムをまとめてしまいますが、すべてはInterface,abstractがオブジェクト指向のすべてだと思っているからです。(やや言い過ぎかも)  
先ほど紹介したサイトではカプセル化が最重要と書いていますが、私はポリモーフィズムが最重要と考えています。  
ここがしっかりできていれば、追加変更に対して非常に強くなるためです。  
課題の例をだします。  
初めに要件として、三角形の面積を計算したいというものがありましたが、長方形、円の面積も計算したいとなってきます。  
それらの面積計算は各クラスに独自計算させればいいですが(カプセル化)、それらすべての面積をまとめて計算したい場合どうすればいいでしょうか。  
以下のようなコードを書きますか？

```csharp
public double CalcAll(IEnumerable<Triangle> triangles, IEnumerable<Square> squares, IEnumerable<Circle> circles)
{
    return triangles.Sum(triangle => triangle.CalcArea()) + squares.Sum(square => square.CalcArea()) + circles.Sum(circle => circle.CalcArea());
}
```

```csharp
public double CalcAll(IEnumerable<double> areas)
{
    return areas.Sum(x => x);
}

// 使う側
var list = new List<double>();
list.AddRange(triangles.Select(triangle => triangle.CalcArea()));
list.AddRange(squares.Select(square => square.CalcArea()));
list.AddRange(circles.Select(circle => circle.CalcArea()));
CalcAll(list);
```

こんなことはしたくないです。  
そこでInterfaceの出番です。  
IShapeというinterfaceを作ってCalcAreaという計算式のみ定義しましょう。  
interfaceとは、取扱説明書のようなものです。IShapeというものは、面積をもってますよ！ということをただ宣言しているだけです。  
それがとても重要で、interfaceを継承するクラスは **そこに書かれているメソッド、プロパティは必ず実装しなければならない** というルールがあります。

```csharp
public interface IShape
{
    double CalcArea();
}

public class Triangle : IShape
{
    public double CalcArea()
    {
        return 底辺 * 高さ / 2;
    }
}

public class Square : IShape
{
    public double CalcArea()
    {
        return 底辺 * 高さ;
    }
}

public class Circle : IShape
{
    public double CalcArea()
    {
        return 半径 * 半径 * Pi;
    }
}
```

これで何が良くなったのでしょう？  
使う側のことを考えましょう。  
これによって、IShapeを通してアクセスする限り、三角形？四角形？どっちかわかんないけどとりあえず面積は計算できるんでしょ？  
という状況になりました。  
具体的にコードを書いてみると、

```csharp
public double CalcAll(IEnumerable<IShape> shapes)
{
    // shapeはCalcAreaのみもってる。それ以外のプロパティ、メソッドにはアクセスできない。
    return shapes.Sum(shape => shape.CalcArea());
}
 
var list = new List<IShape>();

// 三角形も、四角形も円もIShapeさんなので、Listに詰め込める
list.Add(new Triangle());
list.Add(new Square());
list.Add(new Circle());

// IShapeのListなので当然メソッドが使える
CalcAll(list);
```

こうすれば、新たに面積計算したい図形が出てきた場合、IShapeさえ継承させておけばCalcAllも使えます。  
拡張保守がしやすい設計になりました。
