using HtmlAgilityPack;

namespace WebScraping
{
	internal class Program
	{
		public const string name = "example";
		
		private const string urlPreFix = "https://";
		private const string urlPostFix = ".com/";

		static void Main(string[] args)
		{
			HtmlWeb web = new HtmlWeb();
			HtmlDocument doc = web.Load(MakeUrl(name));

			var title = doc.DocumentNode.SelectSingleNode("/html/body/div/h1").InnerText;
			var desc = doc.DocumentNode.SelectSingleNode("/html/body/div/p[1]").InnerText;

			PrintWebsiteUrl();
			PrintElements(title, desc);
		}

		/// <summary>
		/// Combines the given site name to the pre-fix & post-fix used for websites.
		/// (e.g, "example" is converted to "https://example.com/")
		/// </summary>
		/// <param name="siteName">The name of the site to format (e.g, google, NOT google.com)</param>
		/// <returns>A new string represeting the full site URL</returns>
		public static string MakeUrl(string siteName)
		{
			return urlPreFix + siteName + urlPostFix;
		}

		/// <summary>
		/// Prints the full url of the website
		/// </summary>
		private static void PrintWebsiteUrl()
		{
			Console.WriteLine($"Scraping: {MakeUrl(name)}\n");
		}

		/// <summary>
		/// Prints any collection of elements (in string format) 
		/// to the console with line breaks after each element.
		/// </summary>
		/// <param name="elements">The elements to print to the console</param>
		private static void PrintElements(params string[] elements)
		{
			foreach(string element in elements) Console.WriteLine(element + "\n");
		}
	}
}