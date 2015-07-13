internal class Potato
{

}
public class EntryPoint
{
    public void Main()
    {
        Potato myPotato = new Potato();
        //... 
        if (myPotato != null && myPotato.isPeeled && !myPotato.IsRotten)
        {
            Cook(myPotato);
        }

        bool xIsInRange = MinX <= x && x <= MaxX;
        bool yIsInRange = MinY <= y && y <= MaxY;
        if (xIsInRange && yIsInRange && shouldVisitCell)
        {
            VisitCell();
        }
    }


}