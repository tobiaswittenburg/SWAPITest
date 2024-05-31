using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SWAPIUI.Model;

namespace SWAPIUI.Pages
{
    public class IndexModel : PageModel
    {
        public List<StarWarsCharacter> Characters { get; private set; }

        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync("https://swapi.dev/api/people/");
                var APIResults = JsonConvert.DeserializeObject<StarWarsApiResult>(response);

                Characters = APIResults.Results;
            }
        }
    }

}

