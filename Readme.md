# WikiWikiWiki (Wk3)

### We are deployed on Azure!

[https://wikiwikiwiki.azurewebsites.net](https://wikiwikiwiki.azurewebsites.net)

## Description

WikiWikiWiki (Wk3) is a simple wiki platform built in ASP.NET Core, Razor Pages, Entity Framework, Sass, and Markdown. Posts can be created, edited, deleted, searched, and viewed by any users accessing the site. Posts are formatted using Markdown to enable rich text formatting, images, links, etc. 

## Screenshot

### Viewing an article

![Article Screenshot](/assets/article.JPG)

### Responsive Design

![Responsive Screenshot](/assets/responsive.JPG)

### Search

![Search Screenshot](/assets/search.JPG)

## Pages

### /Index

Displays a static page containing a bit of information about WikiWikiWiki and
contact information about the author.

### /Article

Either displays a specific article if an id is provided as an argument or
displays a random article from the database if no id is provided.

### /Edit

Displays a form to create a new article or to edit an existing article if an
id is provided. The form data is sent to one of two HTTP POST handlers to
commit the new/edited article to the database or to delete an existing article
if the delete button was pressed. Posts can be entered in Markdown syntax and
will be rendered using the site's CSS.

### /Search

Displays search results based on a provided searchString in descending
chronological order. Can optionally provide a count argument to only retrieve
a specified number of articles (used in the site to implement the "Latest
5 Articles" feature). Searches on the articles' titles only for scalability
and relevance reasons (common words could potentially return a lot of
unwanted results or out of context results)

## Data Model

Articles are represented in the database as an Article class for code-first
migration via Entity Framework. All pages which need to perform lookups or
modifications to the Article table can do so through the IArticleService
interface through dependency injection (DI).

## Styling

All styling is created via Sass (SCSS). All SCSS files are contained in the
~/style/ directory and are compiled to CSS for rendering via the Sass tool.
Within the style directory there is a base subdirectory containing a user agent
reset and variables used in the other scripts. The elements subdirectory
contains styles for specific elements within the site not dealing with the
overall layout. The layout subdirectory contains styling for major layout
classes for the sidebar, main content area, and the overall site wrapper class.

## Thanks

Special thanks goes out to the contributors of the TagHelper Samples project 
which can be found on the [project's website](http://taghelpersamples.azurewebsites.net)
or on [GitHub](https://github.com/dpaquette/TagHelperSamples).

## Azure Deployment

[https://wikiwikiwiki.azurewebsites.net](https://wikiwikiwiki.azurewebsites.net)

## Change Log

- 5.13.2018 - [Joshua Taylor](mailto:taylor.joshua88@gmail.com) - Initial
release. No unit testing.
