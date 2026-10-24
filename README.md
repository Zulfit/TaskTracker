# Task Tracker

A small Web API for projects and the tasks inside them. Data is stored in a list in the code. There is no database. Swagger is the page used to try the requests.

## Run

Install the .NET 8 SDK, then from this folder:

```powershell
cd TaskTracker
dotnet run --launch-profile http
```

Open http://localhost:5297/swagger

If `dotnet` is not recognized, close the terminal, open a new one, and run the command again. The SDK is on the system path, but a terminal that was already open can keep the old path.

## Sample data

The list starts with two projects:

- **Website Redesign** (id 1): Create wireframes (Todo), Write homepage copy (InProgress)
- **Office Move** (id 2): Book the van (Done), Pack the meeting room (Todo)

Stopping the program and starting it again brings this same list back.

## Completed

| Request | What it returns |
|---|---|
| `GET /api/projects` | Both projects, each with its tasks |
| `GET /api/projects/{id}` | One project with its tasks. Missing ids return not found |
| `GET /api/projects/{id}/tasks` | Only the tasks for that project. Missing ids return not found |
| `POST /api/projects` | Adds a project. Send a name and an optional description. A blank name is rejected. The new project stays until the program stops |
| `PUT /api/projects/{id}` | Changes that project's name and description. The number, created date, and tasks stay the same. A missing id returns not found. A blank name is rejected |
| `DELETE /api/projects/{id}` | Removes that project and the tasks inside it. A missing id returns not found. The response has no body |

## Not completed

 A database and a Blazor page are not built.
