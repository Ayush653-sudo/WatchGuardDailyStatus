public class Rectangle
{
    public double Length { get; set; }
    public double width { get; set; }

    public double Perimeter()
    {
        return 2*(this.Length+this.width);
    }
    public double Area()
    {
        return this.Length * this.width;
    }
    public static void Main()
    {
        Rectangle rectangle = new Rectangle();

    }
}
