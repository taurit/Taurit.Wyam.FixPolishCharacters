# Wyam.FixPolishCharacters

## About the project
This is a quick workaround to un-escape polish characters in Wyam's output HTML files. Such characters are not unsafe in HTML context and don't need to be escaped.

## What problem does it solve?

Wyam 0.18.6 seems to escape all non-ASCII characters (including Polish national characters). It results in output like:

```html
<meta name="description" content="Lista najlepszych artyku&#x142;&#xF3;w opublikowanych na blogu, w porz&#x105;dku chronologicznym."/>
````

instead of just

```html
<meta name="description" content="Lista najlepszych artykułów opublikowanych na blogu, w porządku chronologicznym."/>
````

## How do I hook up to Wyam?

I added the following lines at the bottom of my `config.wyam` file (I'm using Blog recipe).

```C#
// how do i know where to insert this module (eg. "before WriteFiles")? pipelines are defined in:
// https://github.com/Wyamio/Wyam/tree/b36255f3ee461f13356ee6a3a4f91ef859b1b993/src/recipes/Wyam.Web/Pipelines fororder in  pipelines
// https://github.com/Wyamio/Wyam/blob/b36255f3ee461f13356ee6a3a4f91ef859b1b993/src/recipes/Wyam.Blog/Blog.cs

#assembly d:\Projekty\Wyam.FixPolishCharacters\Wyam.FixPolishCharacters\bin\Debug\Wyam.FixPolishCharacters.dll
Console.WriteLine("Inserting FixPolishCharacters for RenderBlogPosts");
Pipelines[Blog.RenderBlogPosts].InsertBefore("WriteFiles", FixPolishCharacters());

Console.WriteLine("Inserting FixPolishCharacters for RenderPages");
Pipelines[Blog.RenderPages].InsertBefore("WriteFiles", FixPolishCharacters());

Console.WriteLine("Inserting FixPolishCharacters for Index");
Pipelines[Blog.Index].InsertBefore("WriteFiles", FixPolishCharacters());

Console.WriteLine("Inserting FixPolishCharacters for Tags");
Pipelines[Blog.Tags].InsertBefore("WriteFiles", FixPolishCharacters());
```

## Project status

I created this project for my own needs and don't expect anyone else to need it.

It might, however, serve as an example of how to create Wyam module that changes content of generated files.