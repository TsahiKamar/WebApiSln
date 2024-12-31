namespace WebApi.Models
{
    public class RepositoryResponse
    {

        public int id { get; set; }
        public string node_id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public bool @private { get; set; } 
        public Owner owner { get; set; }
        public string html_url { get; set; }
        public string description { get; set; }
        public bool fork { get; set; }
        public string url { get; set; }
        public string forks_url { get; set; }
        public string keys_url { get; set; }
        public string collaborators_url { get; set; }
        public string teams_url { get; set; }
        public string hooks_url { get; set; }
        public string issue_events_url { get; set; }
        public string events_url { get; set; }
        public string assignees_url { get; set; }
        public string branches_url { get; set; }
        public string tags_url { get; set; }
        public string blobs_url { get; set; }
        public string git_tags_url { get; set; }
        public string git_refs_url { get; set; }
        public string trees_url { get; set; }
        public string statuses_url { get; set; }
        public string languages_url { get; set; }
        public string stargazers_url { get; set; }
        public string contributors_url { get; set; }
        public string subscribers_url { get; set; }
        public string subscription_url { get; set; }
        public string commits_url { get; set; }
        public string git_commits_url { get; set; }
        public string comments_url { get; set; }
        public string issue_comment_url { get; set; }
        public string contents_url { get; set; }
        public string compare_url { get; set; }
        public string merges_url { get; set; }
        public string archive_url { get; set; }
        public string downloads_url { get; set; }
        public string issues_url { get; set; }
        public string pulls_url { get; set; }
        public string milestones_url { get; set; }
        public string notifications_url { get; set; }
        public string labels_url { get; set; }
        public string releases_url { get; set; }
        public string deployments_url { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime pushed_at { get; set; }
        public string git_url { get; set; }
        public string ssh_url { get; set; }
        public string clone_url { get; set; }
        public string svn_url { get; set; }
        public string homepage { get; set; }
        public int size { get; set; }
        public int stargazers_count { get; set; }
        public int watchers_count { get; set; }
        public string language { get; set; }
        public bool has_issues { get; set; }
        public bool has_projects { get; set; }
        public bool has_downloads { get; set; }
        public bool has_wiki { get; set; }
        public bool has_pages { get; set; }
        public bool has_discussions { get; set; }
        public int forks_count { get; set; }
        public object mirror_url { get; set; }
        public bool archived { get; set; }
        public bool disabled { get; set; }
        public int open_issues_count { get; set; }
        public License license { get; set; }
        public bool allow_forking { get; set; }
        public bool is_template { get; set; }
        public bool web_commit_signoff_required { get; set; }
        public List<string> topics { get; set; }
        public string visibility { get; set; }
        public int forks { get; set; }
        public int open_issues { get; set; }
        public int watchers { get; set; }
        public string default_branch { get; set; }
        public double score { get; set; }

        //
        //  "id": 300479519,
        //  "node_id": "MDEwOlJlcG9zaXRvcnkzMDA0Nzk1MTk=",
        //  "name": "a-patterns",
        //  "full_name": "Reynadi531/a-patterns",
        //  "private": false,
        //  "owner": {
        //    "login": "Reynadi531",
        //    "id": 43875921,
        //    "node_id": "MDQ6VXNlcjQzODc1OTIx",
        //    "avatar_url": "https://avatars.githubusercontent.com/u/43875921?v=4",
        //    "gravatar_id": "",
        //    "url": "https://api.github.com/users/Reynadi531",
        //    "html_url": "https://github.com/Reynadi531",
        //    "followers_url": "https://api.github.com/users/Reynadi531/followers",
        //    "following_url": "https://api.github.com/users/Reynadi531/following{/other_user}",
        //    "gists_url": "https://api.github.com/users/Reynadi531/gists{/gist_id}",
        //    "starred_url": "https://api.github.com/users/Reynadi531/starred{/owner}{/repo}",
        //    "subscriptions_url": "https://api.github.com/users/Reynadi531/subscriptions",
        //    "organizations_url": "https://api.github.com/users/Reynadi531/orgs",
        //    "repos_url": "https://api.github.com/users/Reynadi531/repos",
        //    "events_url": "https://api.github.com/users/Reynadi531/events{/privacy}",
        //    "received_events_url": "https://api.github.com/users/Reynadi531/received_events",
        //    "type": "User",
        //    "user_view_type": "public",
        //    "site_admin": false
        //  },
        //  "html_url": "https://github.com/Reynadi531/a-patterns",
        //  "description": "A repository of patterns collection with many programing language",
        //  "fork": false,
        //  "url": "https://api.github.com/repos/Reynadi531/a-patterns",
        //  "forks_url": "https://api.github.com/repos/Reynadi531/a-patterns/forks",
        //  "keys_url": "https://api.github.com/repos/Reynadi531/a-patterns/keys{/key_id}",
        //  "collaborators_url": "https://api.github.com/repos/Reynadi531/a-patterns/collaborators{/collaborator}",
        //  "teams_url": "https://api.github.com/repos/Reynadi531/a-patterns/teams",
        //  "hooks_url": "https://api.github.com/repos/Reynadi531/a-patterns/hooks",
        //  "issue_events_url": "https://api.github.com/repos/Reynadi531/a-patterns/issues/events{/number}",
        //  "events_url": "https://api.github.com/repos/Reynadi531/a-patterns/events",
        //  "assignees_url": "https://api.github.com/repos/Reynadi531/a-patterns/assignees{/user}",
        //  "branches_url": "https://api.github.com/repos/Reynadi531/a-patterns/branches{/branch}",
        //  "tags_url": "https://api.github.com/repos/Reynadi531/a-patterns/tags",
        //  "blobs_url": "https://api.github.com/repos/Reynadi531/a-patterns/git/blobs{/sha}",
        //  "git_tags_url": "https://api.github.com/repos/Reynadi531/a-patterns/git/tags{/sha}",
        //  "git_refs_url": "https://api.github.com/repos/Reynadi531/a-patterns/git/refs{/sha}",
        //  "trees_url": "https://api.github.com/repos/Reynadi531/a-patterns/git/trees{/sha}",
        //  "statuses_url": "https://api.github.com/repos/Reynadi531/a-patterns/statuses/{sha}",
        //  "languages_url": "https://api.github.com/repos/Reynadi531/a-patterns/languages",
        //  "stargazers_url": "https://api.github.com/repos/Reynadi531/a-patterns/stargazers",
        //  "contributors_url": "https://api.github.com/repos/Reynadi531/a-patterns/contributors",
        //  "subscribers_url": "https://api.github.com/repos/Reynadi531/a-patterns/subscribers",
        //  "subscription_url": "https://api.github.com/repos/Reynadi531/a-patterns/subscription",
        //  "commits_url": "https://api.github.com/repos/Reynadi531/a-patterns/commits{/sha}",
        //  "git_commits_url": "https://api.github.com/repos/Reynadi531/a-patterns/git/commits{/sha}",
        //  "comments_url": "https://api.github.com/repos/Reynadi531/a-patterns/comments{/number}",
        //  "issue_comment_url": "https://api.github.com/repos/Reynadi531/a-patterns/issues/comments{/number}",
        //  "contents_url": "https://api.github.com/repos/Reynadi531/a-patterns/contents/{+path}",
        //  "compare_url": "https://api.github.com/repos/Reynadi531/a-patterns/compare/{base}...{head}",
        //  "merges_url": "https://api.github.com/repos/Reynadi531/a-patterns/merges",
        //  "archive_url": "https://api.github.com/repos/Reynadi531/a-patterns/{archive_format}{/ref}",
        //  "downloads_url": "https://api.github.com/repos/Reynadi531/a-patterns/downloads",
        //  "issues_url": "https://api.github.com/repos/Reynadi531/a-patterns/issues{/number}",
        //  "pulls_url": "https://api.github.com/repos/Reynadi531/a-patterns/pulls{/number}",
        //  "milestones_url": "https://api.github.com/repos/Reynadi531/a-patterns/milestones{/number}",
        //  "notifications_url": "https://api.github.com/repos/Reynadi531/a-patterns/notifications{?since,all,participating}",
        //  "labels_url": "https://api.github.com/repos/Reynadi531/a-patterns/labels{/name}",
        //  "releases_url": "https://api.github.com/repos/Reynadi531/a-patterns/releases{/id}",
        //  "deployments_url": "https://api.github.com/repos/Reynadi531/a-patterns/deployments",
        //  "created_at": "2020-10-02T02:22:38Z",
        //  "updated_at": "2023-07-14T11:32:21Z",
        //  "pushed_at": "2021-10-12T09:13:42Z",
        //  "git_url": "git://github.com/Reynadi531/a-patterns.git",
        //  "ssh_url": "git@github.com:Reynadi531/a-patterns.git",
        //  "clone_url": "https://github.com/Reynadi531/a-patterns.git",
        //  "svn_url": "https://github.com/Reynadi531/a-patterns",
        //  "homepage": "",
        //  "size": 194,
        //  "stargazers_count": 5,
        //  "watchers_count": 5,
        //  "language": "Java",
        //  "has_issues": true,
        //  "has_projects": true,
        //  "has_downloads": true,
        //  "has_wiki": true,
        //  "has_pages": false,
        //  "has_discussions": false,
        //  "forks_count": 36,
        //  "mirror_url": null,
        //  "archived": false,
        //  "disabled": false,
        //  "open_issues_count": 0,
        //  "license": {
        //    "key": "mit",
        //    "name": "MIT License",
        //    "spdx_id": "MIT",
        //    "url": "https://api.github.com/licenses/mit",
        //    "node_id": "MDc6TGljZW5zZTEz"
        //  },
        //  "allow_forking": true,
        //  "is_template": false,
        //  "web_commit_signoff_required": false,
        //  "topics": [
        //    "hacktoberfest",
        //    "hacktoberfest2020",
        //    "hacktoberfest2021",
        //    "patterns",
        //    "patterns-cheat-sheet"
        //  ],
        //  "visibility": "public",
        //  "forks": 36,
        //  "open_issues": 0,
        //  "watchers": 5,
        //  "default_branch": "main",
        //  "score": 1.0
        //}
        //

    }


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class License
{
    public string key { get; set; }
    public string name { get; set; }
    public string spdx_id { get; set; }
    public string url { get; set; }
    public string node_id { get; set; }
}

public class Owner
{
    public string login { get; set; }
    public int id { get; set; }
    public string node_id { get; set; }
    public string avatar_url { get; set; }
    public string gravatar_id { get; set; }
    public string url { get; set; }
    public string html_url { get; set; }
    public string followers_url { get; set; }
    public string following_url { get; set; }
    public string gists_url { get; set; }
    public string starred_url { get; set; }
    public string subscriptions_url { get; set; }
    public string organizations_url { get; set; }
    public string repos_url { get; set; }
    public string events_url { get; set; }
    public string received_events_url { get; set; }
    public string type { get; set; }
    public string user_view_type { get; set; }
    public bool site_admin { get; set; }
}

}
