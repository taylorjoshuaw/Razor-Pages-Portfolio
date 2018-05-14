using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WikiWikiWiki.Models;

namespace WikiWikiWiki.Data
{
    /// <summary>
    /// Seeds the database with example articles
    /// </summary>
    public static class SeedArticles
    {
        /// <summary>
        /// Example articles to be seeded into an empty Article database table
        /// </summary>
        public static Article[] ArticleExamples => new Article[]
        {
            new Article()
            {
                Title = "Markdown Ipsum",
                ImageUrl = "https://placeimg.com/640/480/arch",
                LastUpdated = DateTime.UtcNow,
                Content = @"# Magni aera solida

## Adversos pater

Lorem markdownum mira! Ultro reddunt misceri, horridus cui diro locis grandaevus
patientia tune liquefactis moenibus sunt linguam acta. Tum in labefecit adiuvet.

Nata satis manet domito spumantis poena pendebant desere et antra operisque.
Soror aquilam velint altera hortatibus armigerae temptant ab colebat turba
praecorrumpere dilexit.

## Furor cornua

Elimat in conrepta, ut annosam secuit; cum di, e. Precantia pio quoque versat:
conquerar iter sine remis, cursibus eodem qua per ad pennis. **Fugit** apud fata
in habebatur suisque servit: arcus tympana titulum, est est fer simulacra nulla
quam. Breve dextraque: quibus rara forma, quae enim at ferrum poenam mirabantur
urbem simillimus crescunt Aulidaque.

## Remotos mittuntque auster furta

Palladis dixit. *Et* quarum dat validique ne lumen petunt monticolae quicquid,
lyra minacia tiaris **et** duo exire vacuosque spectare os comis.

## Tacuit magnus est carpere addit

Aut pedum quascumque caelique arbor, calamos hospes et imagine studio marisque
territus mala visis constituunt teque portusque cadit volat. Veni patet sit
[vultum](http://et.net/noctihostisque), tela ingratasque urbes et magna quos.

    if (5) {
        server_client_fi(-1, and_impression);
    } else {
        sequenceNameSsd(18189, graphic_agp_botnet.halftoneCommand(igp_perl, 1,
                utility_dll_power));
    }
    softVle -= vistaHostSli(osdMemoryBot, dimmHard, service_power) + -3;
    kbpsMarkupApp(4, dimmWebClass, bitTweet);
    spoofing_data.hexadecimal = computerVramWarm;
    enterprise_cad_fragmentation.ldap += megabyte;

## Hic facto petenda

Notavi discedunt isdem repandus, alteraque Agaue, domos satis premat. Quod
nequiquam prima obstantis admovet non namque ex desiluit, os vultu umeroque
luxque! Et fugisse trementes lupos videretur cunctaque manet post flumen frater!
Et id ore hic patriae amores, Achaidas [cervice tamen
sit](http://www.et.io/brevis) serpunt licuit natus et nymphas clamoribus mansit.
Dei tonitrumque invitae, dolorque modo [parte
vocantia](http://opemque.com/maneascoeptaeque.aspx) pater nulla furiosaque
rostrum iuvat: lacrimaeque in **meos illic repressit**.

- Certo altismunera armis ter quota
- Ordine facesque quam nutricisque caput horriferamque ferumque
- Obscuraque nate Noemonaque sententia rogantis demisi
- Ille dum qui deriguitque sensit cupidine ab
- Uterque violavit ad nostrum mellis

Recordor celeri. Pennis num vidit et di hanc se narremur, ut simplex et eunti.
At sive, que formosa, et mento lina despice nostri. Cui sciat speciem inmittam
foedera omnes madefacta auro sonum armata echidnae quam seu habuit!",
            },
            new Article()
            {
                Title = "Examples of Markdown Styling",
                ImageUrl = "https://placeimg.com/640/480/animals",
                LastUpdated = DateTime.UtcNow,
                Content = @"An h1 header
============

Paragraphs are separated by a blank line.

2nd paragraph. *Italic*, **bold**, and `monospace`. Itemized lists
look like:

  * this one
  * that one
  * the other one

Note that --- not considering the asterisk --- the actual text
content starts at 4-columns in.

> Block quotes are
> written like so.
>
> They can span multiple paragraphs,
> if you like.

Use 3 dashes for an em-dash. Use 2 dashes for ranges (ex., ""it's all
in chapters 12--14""). Three dots ... will be converted to an ellipsis.
Unicode is supported. ☺



An h2 header
------------

Here's a numbered list:

 1. first item
 2. second item
 3. third item

Note again how the actual text starts at 4 columns in (4 characters
from the left side). Here's a code sample:

    # Let me re-iterate ...
    for i in 1 .. 10 { do-something(i) }

As you probably guessed, indented 4 spaces. By the way, instead of
indenting the block, you can use delimited blocks, if you like:

~~~
define foobar() {
    print ""Welcome to flavor country!"";
}
~~~

(which makes copying & pasting easier). You can optionally mark the
delimited block for Pandoc to syntax highlight it:

~~~python
import time
# Quick, count to ten!
for i in range(10):
    # (but not *too* quick)
    time.sleep(0.5)
    print i
~~~



### An h3 header ###

Now a nested list:

 1. First, get these ingredients:

      * carrots
      * celery
      * lentils

 2. Boil some water.

 3. Dump everything in the pot and follow
    this algorithm:

        find wooden spoon
        uncover pot
        stir
        cover pot
        balance wooden spoon precariously on pot handle
        wait 10 minutes
        goto first step (or shut off burner when done)

    Do not bump wooden spoon or it will fall.

Notice again how text always lines up on 4-space indents (including
that last line which continues item 3 above).

Here's a link to [a website](http://foo.bar), to a [local
doc](local-doc.html), and to a [section heading in the current
doc](#an-h2-header). Here's a footnote [^1].

[^1]: Footnote text goes here.

Tables can look like this:

size  material      color
----  ------------  ------------
9     leather       brown
10    hemp canvas   natural
11    glass         transparent

Table: Shoes, their sizes, and what they're made of

(The above is the caption for the table.) Pandoc also supports
multi-line tables:

--------  -----------------------
keyword   text
--------  -----------------------
red       Sunsets, apples, and
          other red or reddish
          things.

green     Leaves, grass, frogs
          and other things it's
          not easy being.
--------  -----------------------

A horizontal rule follows.

***

Here's a definition list:

apples
  : Good for making applesauce.
oranges
  : Citrus!
tomatoes
  : There's no ""e"" in tomatoe.

Again, text is indented 4 spaces. (Put a blank line between each
term/definition pair to spread things out more.)

Here's a ""line block"":

| Line one
|   Line too
| Line tree

and images can be specified like so:

![example image](http://placeimg.com/320/320/nature)

Inline math equations go in like so: $\omega = d\phi / dt$. Display
math should get its own line and be put in in double-dollarsigns:

$$I = \int \rho R^{2} dV$$

And note that you can backslash-escape any punctuation characters
which you wish to be displayed literally, ex.: \`foo\`, \*bar\*, etc.",
            },
            new Article()
            {
                Title = "Some Quotes and Markdown Examples",
                ImageUrl = "https://placeimg.com/640/480/tech",
                LastUpdated = DateTime.UtcNow,
                Content = @"A First Level Header
====================

A Second Level Header
---------------------

Now is the time for all good men to come to
the aid of their country. This is just a
regular paragraph.

The quick brown fox jumped over the lazy
dog's back.

### Header 3

> This is a blockquote.
> 
> This is the second paragraph in the blockquote.
>
> ## This is an H2 in a blockquote"
            }
        };

        /// <summary>
        /// Tries to seed example articles into an empty Article database table. Simply
        /// returns if the Article table has any rows.
        /// </summary>
        /// <param name="services">Service provider to be provided from the entry point
        /// of this web application</param>
        /// <returns>A Task object used for synchronization</returns>
        public static async Task Initialize(IServiceProvider services)
        {
            // Create a new WkDbContext instance to interact with the database
            using (WkDbContext context = new WkDbContext(
                services.GetRequiredService<DbContextOptions<WkDbContext>>()))
            {
                // If there are any articles, just return
                if (await context.Articles.AnyAsync())
                {
                    return;
                }

                // Ensure that the database has been created
                await context.Database.EnsureCreatedAsync();

                // Add all of the example articles from this class and save changes
                await context.Articles.AddRangeAsync(ArticleExamples);
                await context.SaveChangesAsync();
            }
        }
    }
}
