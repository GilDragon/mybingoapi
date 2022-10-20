var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<int> Bingonumbs = new List<int>();

app.MapGet("/add", () => getNum());
app.MapGet("/add/{lowernumb}/{uppernumb}", (int lowernumb, int uppernumb) => getNum2(lowernumb, uppernumb));
app.MapGet("/exp/{base1}/{exp}", (int base1, int exp) => getNum3(base1, exp));
app.MapGet("/factorial/{factnumb}", (int factnumb) => getNum4(factnumb));
app.MapGet("/bingo/draw/{howmany}", (int howmany) => BingoNum(howmany));
app.MapGet("/bingo/check/{thisnumb}", (int thisnumb) => checknumb(thisnumb));
app.MapGet("/bingo/view", () => drawlist());
app.MapGet("/bingo/reset", () => deleteeverything());




int getNum()
{
    Random numb = new Random();
    int num = numb.Next(1, 100);
    // test if numb comes with 1 and 2 set as (1,2)
    return num;
}
string BingoNum(int howmany)
{
    for (int i = 0; i<= howmany; i++)
    {
        if (Bingonumbs.Count < howmany)
        {
            Random rannumb = new Random();
            var number = rannumb.Next(1, 101);

            while (Bingonumbs.Contains(number))
            {
                number = rannumb.Next(1, 101);
            }
            Bingonumbs.Add(number);
            return $"the number {number.ToString()} has been added";
        }
    
    }
    return $"{howmany.ToString()} numbers have been added.";

}
string checknumb(int thisnumb) {
    if(Bingonumbs.Contains(thisnumb)) {
        return "true";
    }
    else{
        return "False";
    }
}
List <int> drawlist () {
    return Bingonumbs;
}
string deleteeverything () {
    Bingonumbs.Clear();
    return "your drawn numbers have been deleted";
}


int getNum2(int lowernumb, int uppernumb)
{
    Random numb = new Random();
    int num = numb.Next(lowernumb, uppernumb);
    return num;
}

int getNum3(int base1, int exp)
{

    var totalnum = 1;

    for
        (int i = 0; i < exp; i++)
    {

        totalnum = totalnum * base1;
    }

    return totalnum;
}

int getNum4(int factnumb)
{

    var totalnum2 = 1;
    for
        (int i = factnumb; i >= 1; i--)
    {

        totalnum2 = totalnum2 * i;
        if (factnumb >= 31)
        {
            return totalnum2 = -10000000;
        }
    }

    return totalnum2;
}
// if the number is too long =0



app.Run();