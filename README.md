# StorageTransfer

An easy command to allow players to quickly transfer all items from inventory to storage. 

## Features

- `/depositall` deposits all items in a players inventory into the storage they are looking at if close enough and if the storage has enough space.
- Blacklist certain items within the config
- Change the distance away from the storage players can be with config

## Example Configuration 

```xml
<?xml version="1.0" encoding="utf-8"?>
<StorageTransferConfiguration xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <BlacklistedItems>
    <unsignedShort>519</unsignedShort>
    <unsignedShort>1241</unsignedShort>
  </BlacklistedItems>
  <MaxDistance>5</MaxDistance>
</StorageTransferConfiguration>
```
