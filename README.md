# Unity Save
Module to handle saveing and loading data.

## Dependencies
- [Newtonsoft Json](https://docs.unity3d.com/Packages/com.unity.nuget.newtonsoft-json@2.0/manual/index.html)

## How to

### Set value
```cs
Save.SetValue("Key", 5f);
```

### Get value
```cs
float _value = (float) Save.GetValue("Key");
```

### Save data local
```cs
Save.SaveLocal();
```

### Load data local
```cs
Save.LoadLocal();
```
