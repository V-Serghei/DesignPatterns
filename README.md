# Design Patterns in C#

A reference catalogue of Gang-of-Four design patterns implemented in C# (.NET 10).
Each pattern lives in its own folder with one or more self-contained examples.
Client code that wires the examples together is collected under `Client/`.

## Tech stack

- **Language:** C# 14
- **Runtime:** .NET 10 (LTS)
- **IDE:** JetBrains Rider / Visual Studio

## Quick start

```bash
start.bat
```

## Patterns covered

### Creational
| Pattern | Location |
|---|---|
| Abstract Factory | `DesignPatterns/AbstractFactory/` |
| Builder | `DesignPatterns/BUILDER/` |
| Prototype | `DesignPatterns/PROTOTYPE/` |

### Structural
| Pattern | Location |
|---|---|
| Adapter | `DesignPatterns/ADAPTER/` |
| Bridge | `DesignPatterns/BRIDGE/` |
| Composite | `DesignPatterns/Composite/` |
| Decorator | `DesignPatterns/Decorator/` |
| Facade | `DesignPatterns/Facade/` |
| Flyweight | `DesignPatterns/Flyweight/` |
| Proxy | `DesignPatterns/Proxy/` |

### Behavioral
| Pattern | Location |
|---|---|
| Chain of Responsibility | `DesignPatterns/ChainOfResponsibility/` |
| Command | `DesignPatterns/Command/` |
| Mediator | `DesignPatterns/Mediator/` |
| Memento | `DesignPatterns/Memento/` |
| Observer | `DesignPatterns/Observer/` |
| State | `DesignPatterns/State/` |
| Strategy | `DesignPatterns/Strategy/` |
| Visitor | `DesignPatterns/VISITOR/` |

## Architecture

```
DesignPatterns.sln
└── DesignPatterns/          # single console project
    ├── <Pattern>/           # one folder per pattern
    │   └── Ex1/, ex2/, …   # numbered examples
    └── Client/              # entry-point wiring for each pattern
```
