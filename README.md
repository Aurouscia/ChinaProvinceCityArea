# ChinaProvinceCityArea
中华人民共和国行政区划数据（.net版）  
仅支持```.net8.0```及以上  
仅支持精确到区县

## 用法
在nuget包管理器搜索并安装ChinaProvinceCityArea
```
using ChinaProvinceCityArea
var res = ChinaAreaHelper.Get(code);
res.ProvinceName
res.CityName
res.AreaName
```

## 声明
数据来自npm包 ```@province-city-china```  
https://github.com/uiwjs/province-city-china

## License
MIT