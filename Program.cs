using System; // Листинг 5. Программа на объектно-ориентированном языке C#
namespace ConAppl_OOP21_c32_35
{ /*
* В мире ООП все объекты item (товар) являются экземплярами класса Item.
* Класс Item представляет товар так, как его видит покупатель,
* когда может положить его в тележку для магазинов
* самообслуживания или когда оплачивает его с помощью кассового
* аппарата. На примере класса Item демонстрируется понятие класса в ООП.
*/
public class Item // начало КЛАССА Item ////////////////////////////////////////////////////////////
{ // Характеристики товара:
private double unit_price; // 1) цена единицы товара,
private double discount; // 2) скидка с цены в процентах; скидки может не быть,
private int quantity; // 3) количество товара,
private String description; // 4) описание товара,
private String id; // 5) код товара.

public Item(String id, String description, int quantity, double price)
{ // начало КОНСТРУКТОРА Item() класса Item
this.id = id;
this.description = description;
if( quantity >= 0 )
{
this.quantity = quantity;
}
else 
{
this.quantity = 0;
}
this.unit_price = price;
} // окончание КОНСТРУКТОРА Item() класса Item

public double Adjusted_Total()
{ // в этом МЕТОДе выполняется расчет итоговой цены приобретаемого товара
double total = unit_price * quantity;
double total_discount = total * discount;
double adjusted_total = total - total_discount;
return adjusted_total;
}

public double Discount //СВОЙСТВО Discount : set/get процентную скидку с цены
{
set
{
if( discount <= 1.00 )
{
this.discount = value; // discount = 0.15
}
else
{
this.discount = 0.0;
}
}
get
{
return discount;
}
}

public int Quantity // СВОЙСТВО Quantity : set/get количество товара
{
set
{
if (quantity >= 0)
{
this.quantity = value;
}
}
get
{
return quantity;
}
}

public String Id // СВОЙСТВО Id : get код товара
{
get { return id; }
}

public String Description // СВОЙСТВО Description : get описание товара
{
get {return description;}
}
} /////////////////////////////// конец КЛАССА Item /////////////////////////////////////////////////////////////////////////////

public class ItemExample //////////////// Начальный класс ItemExample /////////////////////////////
{ // Функция Main демонстрирует cоздание объектов и работу с ними.
public static void Main( String [ ] args ) ////////////////////////////////////////////////////////////////////////////////
{
// конструктор Item() создает товары (ОБЪЕКТЫ) класса Item, которые
 // имеют след-е атрибуты: код, описание, количество, цена за единицу
 Item milk = new Item("молочный-O1l", "Молоко (литр) ", 2, 2.50);
 Item yogurt = new Item("молочный-032", "Персиковый йогурт", 4, 0.68);
 Item bread = new Item("пекарня-023", "Нарезанный хлеб ", 1, 2.55);
 Item soap = new Item("для дома-21", "6 упаковок мыла ", 1, 4.51);

 // применение дисконтной карты - предоставлена скидка только на стоимость молока
 milk.Discount = 0.15 ;

 // получаем цены на товары, откоректир-ные с учетом скидки и количества товара
 double milk_price = milk.Adjusted_Total();
 double yogurt_price = yogurt.Adjusted_Total();
 double bread_price = bread.Adjusted_Total();
 double soap_price = soap.Adjusted_Total();

 // напечатать квитанцию
 Console.WriteLine("Благодарю Вас за ваши покупки.");
 Console.WriteLine("Пожалуйста, приходите снова!\n");
 Console.WriteLine(milk.Discount + "\t\t" + milk.Quantity + 
 "\t\t" + milk.Description + "\t $" + milk_price);
 Console.WriteLine(yogurt.Id + "\t\t\t" + yogurt.Description + "\t $" + yogurt_price);
 Console.WriteLine(bread.Discount + "\t\t\t\t" + bread.Description + "\t $" + bread_price);
 Console.WriteLine("\t\t\t\t" + soap.Description + "\t $" + soap_price);

 // подсчитать и напечатать сумму - стоимость всей покупки
 double total = milk_price + yogurt_price + bread_price + soap_price;
 Console.WriteLine("\n\t\t\t\tОбщая цена товаров \t $" + total);
 Console.ReadLine();
 } /////////////////////////////////////// конец метода Main ///////////////////////////////////////////////////////////////////////
 } ///////////////////////////////////// конец класса ItemExample ////////////////////////////////////////////////////////////
 } 