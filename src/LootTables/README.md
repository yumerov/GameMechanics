# Loot tables

A data structure used to determine what the drop/loot is. It can be from an ordinary enemy, boss or inanimate game object like chest.

## Guarantee

Guaranteed drop/loot. Example: each enemy drops predetermined amount of experience points and given amount of gold.

## One of Many

Getting one item of many items. Example: the mob can drop one of given weapon or armor set.

## Composite

Contains at least one loot table instance. When try to get loots, combines the result of composited loot tables.
Example: Composite of guarantee and one of many - guaranteed experience, gold and one of many weapons/armors.