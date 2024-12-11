# ChinaProvinceCityArea
中华人民共和国大陆地区行政区划数据（.net版）  
仅支持```.net8.0```及以上  
仅支持精确到区县  
不包括已撤销的区划

## 用法
在nuget包管理器搜索并安装ChinaProvinceCityArea
```
using ChinaProvinceCityArea
var res = ChinaAreaHelper.Get(code);
res.ProvinceName
res.CityName
res.AreaName
```

420000 => { 湖北省, null, null }  
420100 => { 湖北省, 武汉市, null }  
420102 => { 湖北省, 武汉市, 江岸区 }  
428888 => { 湖北省, null, null }  
888888 => { null, null, null }  
500238 => { 重庆市, 市辖区, 巫溪县 }  
429021 => { 湖北省, 直辖区县, 神农架林区 }  
  
20102 => null  //位数错误的返回null  
020102 => null  //没有0开头的省份代码，肯定有误   
4201020 => null  //位数错误的返回null  

## 声明
数据来自npm包 ```@province-city-china```  
https://github.com/uiwjs/province-city-china  

### 其基础上改动
四个省直辖区县：  
429000, 469000, 659000, 419000  
改名为“直辖区县”  
  
添加五个直辖市（重庆算两个）下属的虚拟地级市：  
110100, 120100, 310100, 500100, 500200  
起名为“市辖区”

## 目录结构
ChinaProvinceCityArea：数据和简易查询工具  
ChinaProvinceCityArea.Migrator：数据迁移脚本  
ChinaProvinceCityArea.Test：单元测试  
MigrationSource：引用了上述npm包的package.json，npm install后即可从node_modules迁移数据

## License
MIT