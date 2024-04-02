using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dh.test.API.Model
{

    public class SearchResultsResp
    {
        public Meta meta { get; set; }
        [JsonProperty("search-results")]
        public SearchResults[] searchresults { get; set; }
    }

    public class Meta
    {
        public int page { get; set; }
        public bool has_next { get; set; }
        public bool has_previous { get; set; }
    }

    public class SearchResults
    {
        public long id { get; set; }
        public int position { get; set; }
        public float score { get; set; }
        public int target_id { get; set; }
        public string target_type { get; set; }
        public int course { get; set; }
        public int course_owner { get; set; }
        public int?[] course_authors { get; set; }
        public string course_title { get; set; }
        public string course_slug { get; set; }
        public string course_cover { get; set; }
        public object lesson { get; set; }
        public object lesson_owner { get; set; }
        public object lesson_title { get; set; }
        public object lesson_slug { get; set; }
        public object lesson_cover_url { get; set; }
        public object step { get; set; }
        public object step_position { get; set; }
        public object comment { get; set; }
        public object comment_parent { get; set; }
        public object comment_user { get; set; }
        public object comment_text { get; set; }
    }
}
