```mermaid
        classDiagram
        Booking <.. Person
        Booking <.. Worker
        Booking <.. Room
        Menu .. TypeEat
        Worker .. Post
        Room .. TypeRoom
        BaseAuditEntity --|> Booking
        BaseAuditEntity --|> Person
        BaseAuditEntity --|> Worker
        BaseAuditEntity --|> Menu
        BaseAuditEntity --|> Room
        IEntity ..|> BaseAuditEntity
        IEntityAuditCreated ..|> BaseAuditEntity
        IEntityAuditDeleted ..|> BaseAuditEntity 
        IEntityAuditUpdated ..|> BaseAuditEntity
        IEntityWithId ..|>
        class IEntity{
            <<interface>>
        }
        class IEntityAuditCreated{
            <<interface>>
            +DateTimeOffset CreatedAt
            +string CreatedBy
        }
        class IEntityAuditDeleted{
            <<interface>>
            +DateTimeOffset? DeletedAt
        }
        class IEntityAuditUpdated{
            <<interface>>
            +DateTimeOffset UpdatedAt
            +string UpdatedBy
        }
        class IEntityWithId{
            <<interface>>
            +Guid Id
        }
        class Booking{
        +string NumberRoom
        +string PriceRoom
        +string FIOWorker
        +string FIOPerson
        +DateTime DateReg
        +DateTime DateStart
        +DateTime DateEnd
        }
        class Menu{
        +string Name
        +string Price
        +string Description
        +string TypeEat
        }
        class Person{
        +string FIO
        +string Email
        +string Phone
        +string Login
        +string Password
        +DateTime Birthday
        +string Passport
        +string Past
        }
        class Worker{
        +string FIO
        +string Email
        +string Phone
        +string Login
        +string Password
        +DateTime Birthday
        }
        class Room{
        +string Number
        +int NumberOfSeats
        +int NumberOfRooms
        +string Price
        +string Description
        +string TypeRoom
        }
        class Post {
          <<enumeration>>
          None(Неизвестно)
          Admin(Администратор)
          Manage(Менеджер)
        }
        class TypeRoom {
          <<enumeration>>
          None(Неизвестно)
          VIP(VIP)
          Comfort(Комфорт)
          Economy(Эконом)
        }
        class TypeEat {
          <<enumeration>>
          None(Неизвестно)
          Breakfast(Завтрак)
          Lunch(Обед)
          AfternoonSnack(Полдник)
          Supper(Ужин)
        }
        class BaseAuditEntity {
            <<Abstract>>        
        } 
```
