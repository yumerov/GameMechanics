using Exception = Common.Exception;

namespace LootTables;

public class MissingLootTableException(Type type) : Exception(message: $"Missing loot table for {type.Name}");