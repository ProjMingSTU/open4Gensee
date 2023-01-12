using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
//Console.WriteLine("清除线程");
//Console.ReadLine();
Console.WriteLine("Type subject:");
//Console.WriteLine("zh=中文，x=串语，y=串数，yz=驿站,cl=班级");
string n = Console.ReadLine();
int i = 0;
//为方便录入，使用硬编码。
//string[] subjects = { "zh", "ma", "7", "en", "ph", "ch", "bi", "yz", "cl", "x", "y" };
//string[] rooms = { "25293291", "88023250", "56842453", "79766997", "44167756", "82083249", "22311079", "01131917", "29711377", "92893546", "43366738" };
//string[] pws = { "646836", "351853", "923878", "231625", "327390", "550686", "517390", "708249", "130222", "451022", "535779" };
//foreach (string subject in subjects)
//{
//    if (subject == n)
//    {

//        break;

//    }
//    else if (subject != n && subjects.Length == i++)
//    {
//        Console.WriteLine("room:");
//        rooms[i] = Console.ReadLine();
//        Console.WriteLine("password:");
//        pws[i] = Console.ReadLine();
//        break;
//    }
//    i++;
//}
//I don't know why it doesn't work.
/*while (subjects.Length>=i+1)
{
    if (n==subjects[i] )
    {

        break;
        
    }
    else if (subjects[i] != n && subjects.Length == i+1)
    {
        Console.WriteLine("room:");
        rooms[i] = Console.ReadLine();
        Console.WriteLine("password:");
        pws[i] = Console.ReadLine();
        break;
        
    }
    i++;
}*/
Console.WriteLine("room:");
 string room = Console.ReadLine();
Console.WriteLine("password:");
string pw = Console.ReadLine();
string url = $"http://jhgkqrz.gensee.com/training/site/s/{room}?nickname=&token={pw}";
Console.WriteLine(url);
string htmlStr;
WebRequest request = WebRequest.Create(url);            //实例化WebRequest对象  
WebResponse response = request.GetResponse();           //创建WebResponse对象  
Stream datastream = response.GetResponseStream();       //创建流对象  
Encoding ec = Encoding.Default;
ec = Encoding.UTF8;
StreamReader reader = new StreamReader(datastream, ec);
htmlStr = reader.ReadToEnd();                  //读取网页内容  
reader.Close();
datastream.Close();
response.Close();
//这段是网上找的，看不懂，结果是获得了html
string pattern = @"gensee://[0-9a-z]+";
Match match = Regex.Match(htmlStr, pattern);
Process.Start(@"D:\gsLauncher\gsLauncher.exe", match.Value);
//提取gensee协议并以其打开软件