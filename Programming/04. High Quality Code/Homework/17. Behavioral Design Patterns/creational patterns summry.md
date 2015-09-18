Singleton
---
Това е вероятно най-противоречивия патърн. Идеята е да се създаде инстанция на обект, която да е единствена за приложението и да няма как да се инстанцира друг обект по никакъв начин и осигурява глобален достъп до нея. За това конструкторът обикновено е прайвът или протектед. Достъпът се осъществява чрез метод или пропърти, които гарантират, че винаги ще се подава една и съща инстанция на съответния тип. Самият тип се грижи за инициализирането й. Често се бърка сингълтън с глобална променлива, но единственото общо между тях е че са достъпни глобално в цялото приложение. За разлика от глобалната променлива сингълтъна се грижи за създаването и достъпа до инстанцията. Глобалната променлива просто осигурява референция към обект. Тя не се грижи за създаването му, нито може да контролира достъпа по някакъв начин.
За създаването на сингълтън обикновено се използва т.нар. похват лейзи лоудинг - сингълтън не се инстанцира до момента, когато бъде направена някаква референция към него. Това води и до най-големият проблем свързан с многонишковото програмиране. Необходимо е да се направят допълнителни проверки за подсигуряване на използването на една единствена инстанция от всички нишки. В С# това се осигурява чрез ключовата дума lock. В противен случай може да се получи инстанциране на два различни обекта в паметта, към които сочат различни нипки и част от операциите свързани със сингълтъна да бъдат безвъзвратно загубени след прекратяването на работата на сътоветната нишка. Ще останат промените направени само от последната нишка, която е успяла да инстанцира сингълтън. Други проблеми са tight coupling и нарушаване на SRP. Tight coupling прави сингълтъна много труден за тестване. Това може да се компенсиа ако се направи абстракция на сингълтъна. 

Factory method, Abstract factory
---
Фактори патърните имат за цел да скрият подробностите около създаването на определени инстанции на даден тип (клас). Цялата сложност с извикването на конструкторите и инициализацията остава невидима отвън. С това се изчерпва т.нар. Simple Factory.
Factory method-а позволява използването на подходът simple factory чрез абстракция. Конкретното фактори, което ще се използва е наследник на този абстрактен клас или имплементира интерфейс, и по този начин може да се подават различни факторита отвън, без да има нужда да се променя кодът отвътре (OPEN-CLOSE principle). Абстрактният клас фактори връща абстрактен обект или интерфейс, който съответно се имплементира от конкретните обекти на всяко едно конкретно фактори.
Abstract Factory е на практика Facotry Method, който създава повече от един обекти, които имат някаква смислова връзка. В този смисъл абстрактният клас, който се наследява от всички факторита може да се нарече абстракция на някъв реален обект.
Така например ако имаме фактори метод, който произвежда кафета - в зависимост кой наследник се използва нашето приложение ще произвежда мокачино, мачиато и т.н. При абстракт фактори имаме цял магазин за кафета като абстракция за различни магазини за кафе. Всички те произвеждат определен набор от кафета (капучино, макиато, мока и т.н.), но също така могат да произвеждат и различни кроасани. Така на приложението се подава факторито като конкретна имплементация на даден магазин. Самите магазини могат да имплементират фактори методи патърн за всеки един от продуктите.

Builder
---
Билдър патърна се грижи да дефинира стъпките по създаване на даден обект. Той е интерфейс или абстрактен тип, който се имплементира от конкретни билдъри. Самата имплементация на стъпките се дефинира от конкретните билдъри, имплементиращи или наследяващи билдъра. Билдър патърна се използва от Директор клас, или абстракция Директор, която се занимава само и единствено с извикването на стъпките по създаване на даден обект от билдър патърна в определена последователност за да създаде определен обект. 
Например може да имаме директори за създаване на home.html, products.html, register-page.html и т.н. Всеки от тези директори може да вика различни билдъри от тип html - html4 builder, html5 builder и т.н.
Разликата спрямо факторито е че билдър патърн се използва когато имаме нужда да разделим логиката по създаването на обекта от конкретните данни. Факторито обикновено създава обекта с едно извикване на даден метод. Билдъра не се извиква директно, а чрез директор, който се грижи за структурирането на данните от билдъра в определен ред и създаването на крайния обект.


Singleton example:

using System;
 
namespace DoFactory.GangOfFour.Singleton.Structural
{
  /// <summary>
  /// MainApp startup class for Structural
  /// Singleton Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      // Constructor is protected -- cannot use new
      Singleton s1 = Singleton.Instance();
      Singleton s2 = Singleton.Instance();
 
      // Test for same instance
      if (s1 == s2)
      {
        Console.WriteLine("Objects are the same instance");
      }
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Singleton' class
  /// </summary>
  class Singleton
  {
    private static Singleton _instance;
 
    // Constructor is 'protected'
    protected Singleton()
    {
    }
 
    public static Singleton Instance()
    {
      // Uses lazy initialization.
      // Note: this is not thread safe.
      if (_instance == null)
      {
        _instance = new Singleton();
      }
 
      return _instance;
    }
  }
}


Abstract factory example:

using System;
 
namespace DoFactory.GangOfFour.Abstract.Structural
{
  /// <summary>
  /// MainApp startup class for Structural
  /// Abstract Factory Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    public static void Main()
    {
      // Abstract factory #1
      AbstractFactory factory1 = new ConcreteFactory1();
      Client client1 = new Client(factory1);
      client1.Run();
 
      // Abstract factory #2
      AbstractFactory factory2 = new ConcreteFactory2();
      Client client2 = new Client(factory2);
      client2.Run();
 
      // Wait for user input
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'AbstractFactory' abstract class
  /// </summary>
  abstract class AbstractFactory
  {
    public abstract AbstractProductA CreateProductA();
    public abstract AbstractProductB CreateProductB();
  }
 
 
  /// <summary>
  /// The 'ConcreteFactory1' class
  /// </summary>
  class ConcreteFactory1 : AbstractFactory
  {
    public override AbstractProductA CreateProductA()
    {
      return new ProductA1();
    }
    public override AbstractProductB CreateProductB()
    {
      return new ProductB1();
    }
  }
 
  /// <summary>
  /// The 'ConcreteFactory2' class
  /// </summary>
  class ConcreteFactory2 : AbstractFactory
  {
    public override AbstractProductA CreateProductA()
    {
      return new ProductA2();
    }
    public override AbstractProductB CreateProductB()
    {
      return new ProductB2();
    }
  }
 
  /// <summary>
  /// The 'AbstractProductA' abstract class
  /// </summary>
  abstract class AbstractProductA
  {
  }
 
  /// <summary>
  /// The 'AbstractProductB' abstract class
  /// </summary>
  abstract class AbstractProductB
  {
    public abstract void Interact(AbstractProductA a);
  }
 
 
  /// <summary>
  /// The 'ProductA1' class
  /// </summary>
  class ProductA1 : AbstractProductA
  {
  }
 
  /// <summary>
  /// The 'ProductB1' class
  /// </summary>
  class ProductB1 : AbstractProductB
  {
    public override void Interact(AbstractProductA a)
    {
      Console.WriteLine(this.GetType().Name +
        " interacts with " + a.GetType().Name);
    }
  }
 
  /// <summary>
  /// The 'ProductA2' class
  /// </summary>
  class ProductA2 : AbstractProductA
  {
  }
 
  /// <summary>
  /// The 'ProductB2' class
  /// </summary>
  class ProductB2 : AbstractProductB
  {
    public override void Interact(AbstractProductA a)
    {
      Console.WriteLine(this.GetType().Name +
        " interacts with " + a.GetType().Name);
    }
  }
 
  /// <summary>
  /// The 'Client' class. Interaction environment for the products.
  /// </summary>
  class Client
  {
    private AbstractProductA _abstractProductA;
    private AbstractProductB _abstractProductB;
 
    // Constructor
    public Client(AbstractFactory factory)
    {
      _abstractProductB = factory.CreateProductB();
      _abstractProductA = factory.CreateProductA();
    }
 
    public void Run()
    {
      _abstractProductB.Interact(_abstractProductA);
    }
  }
}



Builder example:
using System;
using System.Collections.Generic;
 
namespace DoFactory.GangOfFour.Builder.Structural
{
  /// <summary>
  /// MainApp startup class for Structural
  /// Builder Design Pattern.
  /// </summary>
  public class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    public static void Main()
    {
      // Create director and builders
      Director director = new Director();
 
      Builder b1 = new ConcreteBuilder1();
      Builder b2 = new ConcreteBuilder2();
 
      // Construct two products
      director.Construct(b1);
      Product p1 = b1.GetResult();
      p1.Show();
 
      director.Construct(b2);
      Product p2 = b2.GetResult();
      p2.Show();
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  /// <summary>
  /// The 'Director' class
  /// </summary>
  class Director
  {
    // Builder uses a complex series of steps
    public void Construct(Builder builder)
    {
      builder.BuildPartA();
      builder.BuildPartB();
    }
  }
 
  /// <summary>
  /// The 'Builder' abstract class
  /// </summary>
  abstract class Builder
  {
    public abstract void BuildPartA();
    public abstract void BuildPartB();
    public abstract Product GetResult();
  }
 
  /// <summary>
  /// The 'ConcreteBuilder1' class
  /// </summary>
  class ConcreteBuilder1 : Builder
  {
    private Product _product = new Product();
 
    public override void BuildPartA()
    {
      _product.Add("PartA");
    }
 
    public override void BuildPartB()
    {
      _product.Add("PartB");
    }
 
    public override Product GetResult()
    {
      return _product;
    }
  }
 
  /// <summary>
  /// The 'ConcreteBuilder2' class
  /// </summary>
  class ConcreteBuilder2 : Builder
  {
    private Product _product = new Product();
 
    public override void BuildPartA()
    {
      _product.Add("PartX");
    }
 
    public override void BuildPartB()
    {
      _product.Add("PartY");
    }
 
    public override Product GetResult()
    {
      return _product;
    }
  }
 
  /// <summary>
  /// The 'Product' class
  /// </summary>
  class Product
  {
    private List<string> _parts = new List<string>();
 
    public void Add(string part)
    {
      _parts.Add(part);
    }
 
    public void Show()
    {
      Console.WriteLine("\nProduct Parts -------");
      foreach (string part in _parts)
        Console.WriteLine(part);
    }
  }
}