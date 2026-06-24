# Claude Working Rules

> **Universal template** — copy this file to any repository. Sections marked
> `[PROJECT-SPECIFIC]` should be replaced for each project.

---

## Language

- **Respond to the user in Russian.**
- Write all project files, code, comments, README.md, and this file in **English**.

---

## Git Protocol

1. **No commits** — only the user makes git commits.
   Never run `git commit`, `git push`, `git reset`, or any destructive git command
   without an explicit user request.
2. **All git commands are executed by the user only** — provide commands as
   plain text, never run them via Bash/PowerShell.
3. **Suggest a commit message** — after every set of changes, provide a
   ready-made conventional-commit message for the user to copy.

---

## Documentation

### README.md
- Contains **project description only**: what it is, tech stack, quick start,
  environment variables, architecture overview.
- Must be updated after every significant code change.
- Rules and instructions for Claude go **only** in CLAUDE.md, never in README.md.

### CLAUDE.md (this file)
- Contains Claude's working rules, project context, and conventions.
- Add new rules and agreements here as they arise.
- Keep it up to date; stale rules are worse than no rules.

### .gitignore
- Must cover: build artifacts (`bin/`, `obj/`), IDE files (`.vs/`, `.idea/`),
  secrets (`.env`, `*.user`, `secrets.json`, `appsettings.*.json` except
  `appsettings.json`), OS files (`.DS_Store`, `Thumbs.db`), generated configs.
- Maintain it continuously — add entries whenever new tool output or secrets
  appear in the working tree.

---

## start.bat / stop.bat

**Every project must have these two files at the repository root.**

### start.bat responsibilities
1. **Check prerequisites** — SDK versions, required tools, environment variables.
   Print a clear error and exit if something is missing.
2. **Generate missing configs** — create `.env`, `appsettings.local.json`, or
   other files that must NOT be in git, using safe defaults or prompting the user.
3. **Restore dependencies** — `dotnet restore`, `npm install`, `pip install`,
   Docker pulls, etc.
4. **Build** — compile / bundle the project.
5. **Provision infrastructure** — start Docker containers, apply DB migrations,
   seed data if needed.
6. **Run tests** (optional but recommended on first run or when `--test` flag
   is passed).
7. **Launch the application** — start all processes needed for the app to be
   fully functional.

On **subsequent runs** the script must be idempotent:
- Skip steps already done (e.g. skip restore if `node_modules` is up to date).
- Apply new migrations, rebuild changed code, restart changed services.
- A second run must also produce a fully working application.

### stop.bat responsibilities
1. Stop every process/service that start.bat launched.
2. Gracefully shut down containers, servers, workers.
3. Leave no orphan processes.

### Maintenance rule
**Keep start.bat and stop.bat always accurate and working.**
After every change that affects project setup (new dependency, new env var,
new service, schema migration, config file rename) — update both files
immediately in the same changeset.

---

## Code Style

- No speculative features, no abstractions beyond the current task.
- No comments explaining WHAT code does; only add one when the WHY is
  non-obvious.
- No trailing summaries in responses — the user can read the diff.

---

## [PROJECT-SPECIFIC] Design Patterns Catalogue

- Each pattern gets its own folder under `DesignPatterns/<PatternName>/`.
- Examples are numbered `Ex1/`, `Ex2/`, … (capitalisation is inconsistent in legacy
  folders — keep existing style, use `Ex1/` for new ones).
- Client wiring for every pattern lives in `DesignPatterns/Client/<PatternName>/`.
- Do not mix multiple patterns in a single example.
