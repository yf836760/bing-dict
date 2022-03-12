using HtmlAgilityPack;
using System.Text;

Console.OutputEncoding = Encoding.UTF8; //使console可以正常输出音标
var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);//存放单词本的位置
var writer = new StreamWriter($"{folder}{Path.DirectorySeparatorChar}words.txt", true);//append


string? words = "";
foreach (var word in args)
{
    words += word;
}
CheckWordsLength(words); //bing词典最多接收100个字符
string bingDictURL = "https://cn.bing.com/dict/search?q=";
var html = $@"{bingDictURL}{words}";


HtmlWeb web = new HtmlWeb();
var htmlDoc = web.Load(html);
var htmlDocNode = htmlDoc.DocumentNode;


//单词的匹配
var node = htmlDocNode
    .SelectNodes("//head/meta")
    .Where(node => node.GetAttributeValue("name", "null") == "description")
    .First();


//单词情景
if (node.GetAttributeValue("content", "null") == "词典")
{
    return;
}
else
{
    writer.WriteLine(words);
    writer.Close();
    string dict = node.GetAttributeValue("content", "解析错误");
    int posOfComma = dict.IndexOf("，");
    string outPut = dict.Substring(posOfComma + 1);
    Console.WriteLine($"{outPut}");
}


void CheckWordsLength(string word)
{
    if (words?.Length > 100) 
    {
        Console.WriteLine("字符数量超过100");
        return;
    }
}

/*句子的匹配
var node2 = htmlDocNode
    .SelectSingleNode("//body/div/div/div/div")
    .FirstChild;

var node2Trans = node2.NextSibling.NextSibling;
var node2TransChildnodes = node2Trans.ChildNodes;
string output2 = "";
foreach (var div in node2TransChildnodes)
{
    output2 += div.InnerHtml;
}
*/


/*句子的测试
Console.WriteLine(output2);
Console.WriteLine(node2Trans.OuterHtml);

Console.WriteLine(node2.GetAttributeValue("class", "null"));
*/

/*句子情景的输出
if (node2.InnerHtml == "计算机翻译")
{
    失败啦 可以输出 但是和浏览器的翻译存在差异
}
*/


