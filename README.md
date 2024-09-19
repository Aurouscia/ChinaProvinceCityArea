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
返回的```CityName```可能为null（直辖市（京津）和省直辖区县（仙桃、神农架））  
```ProvinceName```/```AreaName```不可能为null，若为null说明提供的地区代码有误

## 声明
数据来自npm包 ```@province-city-china```  
https://github.com/uiwjs/province-city-china

## License
MIT