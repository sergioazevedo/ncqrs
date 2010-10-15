CREATE TABLE Events
(
	Id GUID NOT NULL,
[TimeStamp] date NOT NULL,

	Name TEXT NOT NULL,
	Version TEXT NOT NULL,

	EventSourceId GUID NOT NULL,
	Sequence LONG  not null,

	Data varbinary NOT NULL
)

CREATE TABLE EventSources
(
	Id GUID NOT NULL, 
	[Type] TEXT NOT NULL,
	[Version] INT NOT NULL
)

CREATE TABLE Snapshots
(
	[EventSourceId] GUID NOT NULL, 
	[Version] INTEGER, 
	[TimeStamp] date NOT NULL, 
	[Type] TEXT NOT NULL, 
	[Data] varbinary NOT NULL
)