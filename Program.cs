using System.Text.RegularExpressions;

string word = "";
foreach(string arg in args)
{
    word += arg + "+";
}
string requestURI = $"https://cn.bing.com/dict/search?q=";
string searchURI = requestURI + word;
HttpClient httpClient = new HttpClient();
httpClient.Timeout = TimeSpan.FromMinutes(500);
HttpResponseMessage response = httpClient.GetAsync(searchURI).Result;
HttpContent content = response.Content;
string result = content.ReadAsStringAsync().Result;
Match m = Regex.Match(result, @"<meta name=""description"".*?>{1}");
string mValue = m.Value;
bool isNetExplained = mValue.Contains("网络释义");
if (!isNetExplained) return;
int pos = mValue.IndexOf("，");
string str = mValue.Substring(pos+1);
int len = str.Length;
str = str.Substring(0, len-4);
Console.WriteLine(str);