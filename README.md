# ScalableMatch

## Overview

This matchmaking service is a cloud-native stateless service designed to handle player requests to join game sessions, ensuring that players are matched based on latency and queueing time. The service is implemented in C# and adheres to clean architecture principles, ensuring a scalable, maintainable, and testable codebase.

## Matchmaking Process

The matchmaking process involves several key steps to ensure that players are efficiently and fairly matched into game sessions. The process is as follows:

1. **Ticket Queueing**: Each player request to join a game creates a matchmaking ticket. The ticket contains information about the player, including their latency, game ID, and the queueing time. Matchmaking tickets with the status "SEARCHING" are queued in the system.
2. **Latency Matching**: Every second the matchmaking service attempts to add players to the session based on their latency, ensuring that all players within a session have similar latency values for an optimal gaming experience.
3. **Session Assigning**: Once the session reaches the desired number of players (between 2 and 10), the session is marked as "CREATED". The tickets involved in the match are updated to "PLACING".
4. **Ticket Dequeueing**: A player can cancell their matchmaking ticket. The cancelled matchmaking tickets marked "CANCLELLED" are ingored by the matchmaker.

## Clean Architecture Overview

The matchmaking service is built using clean architecture principles to ensure that it is easy to maintain, test, and extend. Below is a high-level overview of the clean architecture layers used in this service:



![Clean Architecture](https://habrastorage.org/r/w1560/getpro/habr/upload_files/598/79b/cd3/59879bcd3c10e460d991a8a7576829a5.png)

### 1. **Domain**

- **GameSession**: Represents a game session, including attributes like `Id`, `GameId`, `AcceptBackfill`, `CreatedAt`, `Status` and a list of `Players`.
- **MatchmakingTicket**: Represents a matchmaking request, including `Id`, `Player`, `Status`, `CreatedAt`, and `GameId`.
- **Player**: Represents a player, including `Id` and `Latency`.

### 2. **Application**

- **StartMatchmakingUseCase**: Handles the creation of matchmaking tickets and initiates the matchmaking process.
- **StopMatchmakingUseCase**: Handles the deletion of matchmaking tickets from the ticket pool.
- **AssignSessionUseCase**: Matches players into game sessions based on their latency and creation time.
- **ITicketRepository**: Interface for operations related to matchmaking tickets (e.g., saving, retrieving, updating, and deleting tickets).
- **IGameSessionRepository**: Interface for operations related to game sessions (e.g., saving, retrieving, and updating sessions).

### 3. **Infrastructure**

- **Not implemented yet**: To do: implement the repositories below using IDynamoDbClient based on Data Access Patterns. All queries are meant to read from the corresponding DynamoDB indices for scalability. It might be benefitical to implement integration tests using TestContainers and the local DynamoDB docker image.
- **DynamoDbTicketRepository**: Implements the `ITicketRepository` interface to handle matchmaking ticket operations in DynamoDB.
- **DynamoDbGameSessionRepository**: Implements the `IGameSessionRepository` interface to handle game session operations in DynamoDB.

### 4. **Web.API**

- **MatchmakingController**: Provides endpoints to queue player requests and dequeue requests. Basically, this is the Presentantion Layer.
- **MatchmakingHostedService**: A background service that runs **AssignSessionUseCase** every second. 

### 5. **Unit Tests**
- All the functionality is covered with unit tests according to **TDD** approach.

## Example of architecture diagram
![Cloud diagram example](https://raw.githubusercontent.com/DmitriyV/ScalableMatch/main/img/ArchitectureExample.png)

## Design Considerations

- **Scalability**: The service is designed to support multiple games and millions of players, leveraging DynamoDB for scalable and efficient data storage.
- **Latency-Based Matching**: Players are matched into sessions based on latency, ensuring a fair and enjoyable gaming experience.
- **Clean Architecture**: The code is organized into layers to separate concerns, making it easier to extend and maintain.
- **Persistence (not implemented yet)**: All tickets and game sessions are stored in DynamoDB, ensuring persistent and reliable data management.

## Getting Started

### Prerequisites

- .NET SDK 8.0 or later

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/DmitriyV/ScalableMatch.git
    cd ScalableMatch
    ```

2. Install the dependencies:

    ```bash
    dotnet restore
    ```
3. Build:

    ```bash
    dotnet build
    ```
### Usage

1. Start the application using ScalableMatch.API project.

2. Access the matchmaking endpoints to queue/dequeue player requests via Swagger endpoint
[http://localhost:32776/swagger/index.html](http://localhost:32776/swagger/index.html)