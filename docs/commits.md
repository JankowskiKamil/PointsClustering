# Commit norms

Commits should follow [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/#specification)
specification.

## Commit message

The commit message should be structured as follows:

```
<type>(optional scope1,scope2,...): <optional issue reference> <description>

[optional body]
```

If an element does not have "optional" prefix then it's mandatory

## Commit types

-   build: a commit of the type build changes our build process, adds new artifacts, optimizes it etc. Those will mostly
    be changes to our Earthfile and related.
    'build' changes how software is built. Such changes will produce our binaries differently, but will not change our source code
    (eg. optimized build vs unoptimized, singlefilebinary vs exploded, debug configuration vs production etc.) nor it's external dependencies.
-   chore: a commit of the type chore introduces updates in versions or dependencies, frameworks, tools. Eg. update in a
    nuget dependency, running `nix flake update`, using newer dotnet version.
    'chore' changes everything external to our code (local dev env updates, updating dotnet framework, cleaning our Makefile, bumping nuget deps).
    If nuget update forces changes in our code, this should be another commit type (I'd say a 'fix' to adjust our code to work with newer deps).
-   ci: a commit of the type ci is about changes in our ci pipeline. This involves adding new stages, changing current jobs, fixing
    problems, improving performance.
    'ci' changes nothing related to our program nor its dependencies. Changes only CI behavior. Different jobs may be run, different rules,
    more jobs, less jobs, optimizations etc.
-   docs: a commit of the type docs is about adding documentation to the project. This can involve adding comments to
    the code, adding new files in the `docs/` folder, modifying exiting ones, updating `readme`.
-   feat: a commit of the type feat introduces a new feature to the codebase (this correlates with MINOR in Semantic Versioning).
-   fix: a commit of the type fix patches a bug in your codebase (this correlates with PATCH in Semantic Versioning).
-   infra: a commit of the type infra introduces a change in `k8s` folder or in `cloud` folder. It's about changes to
    the cloud-part of our application.
-   perf: a commit of the type perf introduces a change in the code that is a performance optimization. Eq. we change
    some data structure to allow faster lookups.
-   refactor: a commit of the type refactor changes the code without impacting functionality. This is about removing
    unused code, splitting methods, changing private fields in a class.
    It is also about formatting, properties vs fields, imports ordering, usings, renaming methods.
-   revert: a commit of the type revert describes reverting some previous commit or change. Could either be generated via
    `git revert` or via manual change to the code.
-   test: a commit of the type test is purely about adding/removing/changing tests and/or test helpers, test methods,
    constructors for tests.
-   BREAKING CHANGE: a commit that has a footer BREAKING CHANGE: and appends a ! after the type/scope, introduces a breaking API change (correlating with MAJOR in Semantic Versioning). A BREAKING CHANGE can be part of commits of any type.
    For us, a breaking change most of the time means that migrations are needed.

## Breaking changes

What is a breaking change? Fact about our app:

-   our app is our API
-   our data (graphml at the moment) is our API as well
-   the consumers of our app 'API' are business people, us (devs) and the future contractors
-   plant-graph team is a consumer of our data 'API'

So a breaking change will be anything that would force us to inform and/or require manual intervention from all personas listed above.

Eg. We changed how symbols are represented in symbol library and old verions can no longer be loaded back.
This is a breaking change for everyone as we need to inform all parties that a migration is required (or we need to send
the new files).

## Commit scopes

Most of the time we'll be using 1 or 2 scopes:

```
<type>(optional scopes or functionalities): <description>
```

-   always try to include the project that the commit concerns.
-   optionally include the classname or functionality that was impacted
-   scopes can be ommited when it makes sense. See Examples section.

Projects can be:

-   Backend
-   Tests (project for tests)

```
