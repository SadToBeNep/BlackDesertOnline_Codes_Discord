using BlackDesertOnline_Codes_Discord;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.RegularExpressions;





var t = new Thread(codeScraper.scraper);
t.Start();
var b = new DiscordBotController();
b.RunAsync().GetAwaiter().GetResult();



