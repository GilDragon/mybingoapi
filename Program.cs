var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<int> Bingonumbs = new List<int>();
// make list 리스트 만듦
app.MapGet("/add", () => getNum()); //getnum이라는 int를 출력 print getnum URL주소 뒤에 /add 붙여야함
app.MapGet("/add/{lowernumb}/{uppernumb}", (int lowernumb, int uppernumb) => getNum2(lowernumb, uppernumb));
// int lowernumb 과 int uppernumb 을 입력 하고 getNum2를 출력(입력값에 따라 getNum2가 달라짐) 
//print getNum2 lowernumb and upppernumb are user input getNum2 differs depends on inputs by user
app.MapGet("/exp/{base1}/{exp}", (int base1, int exp) => getNum3(base1, exp));
// 위와 동일 same as above 
app.MapGet("/factorial/{factnumb}", (int factnumb) => getNum4(factnumb));
// Getnerate Factorial number by user's input number 52이상은 안됨 맞나? 너무 큰수 나오면 오류 뜸
app.MapGet("/bingo/draw/{howmany}", (int howmany) => BingoNum(howmany));
// 내가 원하는 수만큼 랜덤번호 만들기 generate random numbers how many times you want 원래 원했던건 100개 임
app.MapGet("/bingo/check/{thisnumb}", (int thisnumb) => checknumb(thisnumb));
// 이제까지 무슨 숫자 나왔는지 체크 하려고 check what number are drawn so far
app.MapGet("/bingo/view", () => drawlist());
app.MapGet("/bingo/reset", () => deleteeverything());
app.MapGet("/bingo/boolcheck/{checkcheck}", (int checkcheck) => Numcheck(checkcheck));
app.MapGet("/bingo/check", (int cheknumb) => NumCheck(cheknumb));

bool NumCheck(int cheknumb) {
    return Bingonumbs.Contains(cheknumb);
}

int getNum()
{
    Random numb = new Random(); // numb 랜덤 넘버 생성인가? 아니면 announce인가?
    int num = numb.Next(1, 100);
    // test if numb comes with 1 and 2 set as (1,2)
    return num;
}
string BingoNum(int howmany) // BingoNum은 string이야 하지만 int howmany를 포함하고 있지 howmany에 따라 값이 달라지나?
// why do I have to int howmany in ()???? because howmany is user's input?
{
    for (int i = 0; i<= howmany; i++)
    {
        if (Bingonumbs.Count < howmany) // Bingonumbs list에 있는 숫자들 개수보다 howmany 설정한 수가 적으면  if 고고 가야쥐
        {
            Random rannumb = new Random(); //rannumb 랜덤넘버 생성? generate random number?
            var number = rannumb.Next(1, 101); // number라는 변수를 생성하는데 rannumb 1부터 100까지 생성 

            while (Bingonumbs.Contains(number)) //Bingonumbs에 있는 숫자들이랑 위에서 나온 random number랑 같다면 while 가야쥐
            // if the number from random number already exists in Bingonumbs' list, then let's do while loop
            {
                number = rannumb.Next(1, 101); //random 넘버 생성하기 while loop에서
            }
            Bingonumbs.Add(number); //중복 된게 없다면 리스트에 추가 if number is not same as in bingonumbs' list then Add to the list
            return $"the number {number.ToString()} has been added"; //number를 string으로 바꿔줘서 출력해야함 같이 쓰려면
        }
    
    }
    return $"{howmany.ToString()} numbers have been added.";

}
string checknumb(int thisnumb) { 
    if(Bingonumbs.Contains(thisnumb)) {
        return "true";
    } // thisnumb 유저 입력값이 Bingonumbs list 에 있다면 true 를 출력 print true if user's input is Bingonumbs' list
    else{
        return "False";
    }
}
bool Numcheck(int checkcheck) {
    return Bingonumbs.Contains(checkcheck);
}



List <int> drawlist () {
    return Bingonumbs; // print everything in Bingonumbs
}
string deleteeverything () {
    Bingonumbs.Clear(); //clear the any number in Bingonums' list
    return "your drawn numbers have been deleted";
}


int getNum2(int lowernumb, int uppernumb)
{
    Random numb = new Random();
    int num = numb.Next(lowernumb, uppernumb);
    return num;
    // lowernumb과 uppernumb 사이에서 랜덤 숫자를 생성 int num = lowernumb과 uppernumb 사이에서 랜덤 숫자
}

int getNum3(int base1, int exp)
{

    var totalnum = 1;

    for 
        (int i = 0; i < exp; i++) // int i가 exp (유저입력값)보다 작으면 계속 for loop 가야함
    {

        totalnum = totalnum * base1; //totalnum은 totalnum 곱하기 base1(유저입력값) 만약에 base1이 2이고 exp가 4면 .
        // totalnum 1 * base1 2 = 2 totalnum아직 i는 0이니까 exp 4보다 작지 그러면 i에 1을 더해주고 다시 loop totalnum2 * base1 2 =totalnum 4
        // totalnum 4* base1 2 = 8 ...............한번더 하면 16 i=4 되니까 루프 탈출
    }

    return totalnum;
}

int getNum4(int factnumb)
{

    var totalnum2 = 1;
    for
        (int i = factnumb; i >= 1; i--) //i가 factnumb일때 i가 1보다 같거나 크면 i에 1을 삐고 루프 돌리기
    {

        totalnum2 = totalnum2 * i; //totalnum2 1 * factnumb(유저입력값 만약에 4면) 1*4(3) = 4  4(i) - 1 =3
        // 다음루프  totalnum2 4 * i 3 = 12 3(i) - 1 =2  다음 값 24 i =1 다음값 24 i =0 루프 종료
        if (factnumb >= 31) // 유저 입력값 factnumb이 31보다 크거나 같으면 totalnum2 를 출력
        {
            return totalnum2 = -10000000;
        }
    }

    return totalnum2;
}
// if the number is too long =0



app.Run();