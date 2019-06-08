# serializer-perf
Performance tests for the most popular serializers.
Binary, Json, Bson.

1. [protobuf-net](https://github.com/mgravell/protobuf-net)
2. [msgpack-cli](https://github.com/msgpack/msgpack-cli)
3. [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)
4. [Jil](https://github.com/kevin-montrose/Jil)
5. [GroBuf](https://github.com/homuroll/GroBuf)
6. [FastJson](https://github.com/mgholam/fastJSON)
7. [ServiceStack.Text](https://github.com/ServiceStack/ServiceStack.Text)
8. [Wire](https://github.com/rogeralsing/Wire)
9. [FsPickler](https://github.com/mbraceproject/FsPickler)
10. [MongoDb Bson](http://mongodb.github.io/mongo-csharp-driver/)
11. [Message shark](https://github.com/rpgmaker/MessageShark)

---
[Array](https://github.com/krezon/serializer-perf/blob/master/src/Models/TinyArray.cs)

``` ini

BenchmarkDotNet=v0.10.1, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel Xeon E312xx (Sandy Bridge)Intel Xeon E312xx (Sandy Bridge)Intel Xeon E312xx (Sandy Bridge)Intel Xeon E312xx (Sandy Bridge), ProcessorCount=4
Frequency=3579545 Hz, Resolution=279.3651 ns, Timer=ACPI
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1055.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1055.0


```

```
              Method |          Mean |     StdErr |      StdDev |        Median | Scaled | Rank |  Gen 0 | Allocated |
-------------------- |-------------- |----------- |------------ |-------------- |------- |----- |------- |---------- |
        'GroBuf [S]' |   188.4655 ns |  1.9203 ns |  13.7133 ns |   185.8794 ns |   1.00 |    1 | 0.0663 |     144 B |
        'GroBuf [D]' |   242.1770 ns |  2.4161 ns |  17.0846 ns |   243.3065 ns |   1.29 |    2 | 0.0410 |      92 B |
 'Message shark [D]' |   463.9720 ns |  4.6074 ns |  17.2394 ns |   462.1928 ns |   2.47 |    3 | 0.1910 |     416 B |
 'Message shark [S]' |   470.3744 ns |  4.7585 ns |  38.9498 ns |   458.5138 ns |   2.51 |    3 | 0.2948 |     632 B |
       'MsgPack [S]' |   537.8919 ns |  5.3509 ns |  46.9541 ns |   535.1492 ns |   2.87 |    4 | 0.1668 |     368 B |
      'Protobuf [S]' |   677.2594 ns |  6.7689 ns |  65.2771 ns |   664.1292 ns |   3.61 |    5 | 0.1899 |     416 B |
           'Jil [S]' |   702.0265 ns |  7.0527 ns |  65.0229 ns |   690.7332 ns |   3.74 |    6 | 0.1849 |     444 B |
           'Jil [D]' |   725.5403 ns |  7.2503 ns |  68.3992 ns |   702.0689 ns |   3.87 |    7 | 0.1418 |     316 B |
      'Protobuf [D]' | 1,098.1546 ns | 12.1206 ns | 119.9874 ns | 1,070.8921 ns |   5.86 |    8 | 0.0996 |     236 B |
       'MsgPack [D]' | 1,294.1002 ns | 12.8191 ns |  85.9934 ns | 1,279.5662 ns |   6.90 |    9 | 0.1557 |     352 B |
     'FsPickler [D]' | 1,595.0745 ns | 17.7768 ns | 176.8766 ns | 1,539.5741 ns |   8.51 |   10 | 0.4183 |     956 B |
  'ServiceStack [S]' | 1,781.3884 ns | 17.5983 ns | 118.0532 ns | 1,763.7225 ns |   9.50 |   11 | 0.1841 |     436 B |
     'FsPickler [S]' | 1,797.1622 ns | 17.8462 ns | 166.4582 ns | 1,789.5191 ns |   9.58 |   11 | 0.5709 |   1.25 kB |
          'Wire [S]' | 1,864.7493 ns | 19.3323 ns | 191.3805 ns | 1,820.7626 ns |   9.94 |   12 | 0.1845 |     440 B |
          'Bson [S]' | 2,733.8986 ns | 29.8263 ns | 290.7107 ns | 2,647.4161 ns |  14.58 |   13 | 0.4389 |   1.12 kB |
          'Wire [D]' | 2,772.3810 ns | 28.7501 ns | 271.2276 ns | 2,727.4938 ns |  14.78 |   13 | 0.3497 |     772 B |
  'ServiceStack [D]' | 2,881.9979 ns | 29.2516 ns | 271.2685 ns | 2,823.1731 ns |  15.37 |   14 | 0.3406 |     780 B |
          'Bson [D]' | 3,168.4989 ns | 31.0959 ns | 265.6836 ns | 3,092.7776 ns |  16.90 |   15 | 0.3340 |     832 B |
     'Json .NET [D]' | 4,149.5662 ns | 44.4423 ns | 352.7496 ns | 4,081.3361 ns |  22.13 |   16 | 1.3293 |   2.86 kB |
     'Json .NET [S]' | 4,258.1643 ns | 44.1136 ns | 441.1360 ns | 4,226.3326 ns |  22.71 |   16 | 0.6170 |    1.4 kB |
      'FastJson [S]' | 4,529.5098 ns | 45.0440 ns | 420.1428 ns | 4,422.5279 ns |  24.15 |   17 | 1.0775 |    2.4 kB |
      'FastJson [D]' | 4,539.0560 ns | 45.3431 ns | 413.0953 ns | 4,453.7689 ns |  24.21 |   17 | 0.7637 |    1.7 kB |
```
---
[Big data with a nested type](https://github.com/krezon/serializer-perf/blob/master/src/Models/BigData.cs)

``` ini

BenchmarkDotNet=v0.10.1, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel Xeon E312xx (Sandy Bridge)Intel Xeon E312xx (Sandy Bridge)Intel Xeon E312xx (Sandy Bridge)Intel Xeon E312xx (Sandy Bridge), ProcessorCount=4
Frequency=3579545 Hz, Resolution=279.3651 ns, Timer=ACPI
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1055.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1055.0


```

```
              Method |       Mean |    StdErr |    StdDev |     Median | Scaled | Rank |  Gen 0 | Allocated |
-------------------- |----------- |---------- |---------- |----------- |------- |----- |------- |---------- |
        'GroBuf [S]' |  1.7350 us | 0.0225 us | 0.2246 us |  1.6645 us |   1.00 |    1 | 1.1548 |   2.53 kB |
        'GroBuf [D]' |  3.5810 us | 0.0354 us | 0.1661 us |  3.5932 us |   2.10 |    2 | 1.2644 |   2.77 kB |
 'Message shark [S]' |  6.0735 us | 0.0602 us | 0.3407 us |  6.0425 us |   3.55 |    3 | 3.1877 |   6.88 kB |
      'Protobuf [S]' |  6.3560 us | 0.0624 us | 0.2858 us |  6.3214 us |   3.72 |    4 | 0.5688 |   1.31 kB |
 'Message shark [D]' |  6.8029 us | 0.0717 us | 0.6607 us |  6.6357 us |   3.98 |    5 | 2.2049 |   5.34 kB |
       'MsgPack [S]' |  9.0252 us | 0.0946 us | 0.9318 us |  8.9016 us |   5.28 |    6 | 1.5376 |   3.48 kB |
           'Jil [S]' | 10.4668 us | 0.1040 us | 0.5972 us | 10.3756 us |   6.13 |    7 | 4.1313 |   8.88 kB |
      'Protobuf [D]' | 12.1471 us | 0.1203 us | 0.8067 us | 11.8845 us |   7.11 |    8 | 1.6124 |   3.52 kB |
           'Jil [D]' | 13.1172 us | 0.1309 us | 0.9880 us | 12.9322 us |   7.68 |    9 | 4.8874 |  10.51 kB |
  'ServiceStack [S]' | 19.0734 us | 0.1863 us | 0.7217 us | 19.1314 us |  11.16 |   10 | 1.5531 |   3.91 kB |
     'FsPickler [D]' | 19.9930 us | 0.2094 us | 2.0628 us | 19.4793 us |  11.70 |   11 | 2.4585 |    5.4 kB |
          'Wire [S]' | 20.4791 us | 0.2031 us | 1.7819 us | 20.0827 us |  11.99 |   11 | 1.6832 |    3.9 kB |
       'MsgPack [D]' | 21.4780 us | 0.2143 us | 1.8306 us | 21.1038 us |  12.57 |   12 | 3.6437 |   7.98 kB |
     'FsPickler [S]' | 23.8471 us | 0.2383 us | 1.3688 us | 23.5048 us |  13.96 |   13 | 3.2284 |   7.11 kB |
     'Json .NET [S]' | 25.9595 us | 0.2574 us | 2.1993 us | 25.6717 us |  15.19 |   14 | 3.8106 |   8.34 kB |
      'FastJson [S]' | 29.0883 us | 0.2897 us | 2.0686 us | 28.7121 us |  17.02 |   15 | 6.6357 |  14.48 kB |
          'Bson [S]' | 29.3519 us | 0.3302 us | 3.3019 us | 28.5343 us |  17.18 |   15 | 5.6543 |  12.35 kB |
     'Json .NET [D]' | 34.3294 us | 0.3412 us | 3.0517 us | 33.8059 us |  20.09 |   16 | 2.5506 |   6.42 kB |
  'ServiceStack [D]' | 35.7763 us | 0.3072 us | 1.1494 us | 35.9805 us |  20.94 |   17 | 6.2349 |  13.72 kB |
          'Wire [D]' | 36.0764 us | 0.3505 us | 1.8874 us | 35.7882 us |  21.11 |   17 | 6.2008 |  13.75 kB |
          'Bson [D]' | 40.1003 us | 0.3985 us | 2.7319 us | 39.5553 us |  23.47 |   18 | 0.3590 |   7.04 kB |
      'FastJson [D]' | 55.6011 us | 0.5513 us | 3.6154 us | 55.3876 us |  32.54 |   19 | 7.2545 |  16.68 kB |
```

---
[Tiny data with attributes](https://github.com/krezon/serializer-perf/blob/master/src/Models/TinyAttributeData.cs)

``` ini

BenchmarkDotNet=v0.10.1, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel Xeon E312xx (Sandy Bridge)Intel Xeon E312xx (Sandy Bridge)Intel Xeon E312xx (Sandy Bridge)Intel Xeon E312xx (Sandy Bridge), ProcessorCount=4
Frequency=3579545 Hz, Resolution=279.3651 ns, Timer=ACPI
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1055.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1055.0


```

```
              Method |          Mean |     StdErr |      StdDev |        Median | Scaled | Rank |  Gen 0 | Allocated |
-------------------- |-------------- |----------- |------------ |-------------- |------- |----- |------- |---------- |
        'GroBuf [S]' |   200.7297 ns |  2.0349 ns |  12.2096 ns |   196.9477 ns |   1.00 |    1 | 0.0902 |     196 B |
        'GroBuf [D]' |   270.6061 ns |  2.9169 ns |  22.2145 ns |   263.7361 ns |   1.35 |    2 | 0.0561 |     140 B |
 'Message shark [S]' |   339.4216 ns |  3.3907 ns |  18.2595 ns |   338.6005 ns |   1.70 |    3 | 0.1919 |     416 B |
 'Message shark [D]' |   371.8428 ns |  3.7143 ns |  20.0023 ns |   369.7118 ns |   1.86 |    4 | 0.0842 |     212 B |
       'MsgPack [S]' |   480.2957 ns |  4.7648 ns |  39.8654 ns |   473.0327 ns |   2.40 |    5 | 0.1892 |     420 B |
      'Protobuf [S]' |   511.4770 ns |  4.6516 ns |  16.1135 ns |   508.1141 ns |   2.56 |    6 | 0.1912 |     416 B |
           'Jil [S]' |   547.7564 ns |  5.4724 ns |  33.7344 ns |   535.1194 ns |   2.74 |    7 | 0.1972 |     460 B |
           'Jil [D]' |   550.8186 ns |  5.5019 ns |  40.4304 ns |   542.5893 ns |   2.75 |    7 | 0.2131 |     460 B |
       'MsgPack [D]' |   649.7887 ns |  6.5268 ns |  45.6876 ns |   648.2762 ns |   3.25 |    8 | 0.1211 |     268 B |
      'Protobuf [D]' |   836.0543 ns |  8.3438 ns |  74.1613 ns |   812.6336 ns |   4.18 |    9 | 0.0396 |     112 B |
          'Wire [S]' |   941.6563 ns |  9.4322 ns |  49.9102 ns |   944.4773 ns |   4.71 |   10 | 0.0428 |     168 B |
  'ServiceStack [S]' |   977.2125 ns |  9.9278 ns |  87.1162 ns |   959.0976 ns |   4.89 |   11 | 0.0353 |     168 B |
          'Wire [D]' | 1,014.9030 ns |  9.8900 ns |  40.7776 ns | 1,020.3399 ns |   5.07 |   12 | 0.1206 |     284 B |
  'ServiceStack [D]' | 1,073.2311 ns | 10.8477 ns |  95.8042 ns | 1,041.5010 ns |   5.37 |   13 | 0.1261 |     284 B |
     'Json .NET [S]' | 1,217.3572 ns | 12.1438 ns | 107.2507 ns | 1,187.7847 ns |   6.09 |   14 | 0.5485 |   1.18 kB |
          'Bson [S]' | 1,584.4430 ns | 15.8634 ns | 139.2009 ns | 1,551.1689 ns |   7.92 |   15 | 0.5139 |   1.11 kB |
     'FsPickler [D]' | 1,675.6548 ns | 18.4852 ns | 182.0585 ns | 1,613.6189 ns |   8.38 |   16 | 0.4623 |   1.02 kB |
     'FsPickler [S]' | 1,810.3951 ns | 18.0441 ns | 128.8603 ns | 1,766.2870 ns |   9.05 |   17 | 0.4979 |   1.25 kB |
     'Json .NET [D]' | 1,868.4857 ns | 18.6982 ns | 146.0379 ns | 1,837.4473 ns |   9.34 |   18 | 1.1835 |   2.53 kB |
          'Bson [D]' | 1,904.8358 ns | 19.7368 ns | 169.7825 ns | 1,866.4976 ns |   9.52 |   18 | 0.2982 |     700 B |
      'FastJson [S]' | 2,152.8086 ns | 21.2944 ns |  95.2315 ns | 2,160.0079 ns |  10.76 |   19 | 1.0955 |   2.36 kB |
      'FastJson [D]' | 3,415.5154 ns | 36.3800 ns | 272.2429 ns | 3,320.5095 ns |  17.07 |   20 | 0.6863 |   1.53 kB |
```

---
[Tiny data](https://github.com/krezon/serializer-perf/blob/master/src/Models/TinyData.cs)

``` ini

BenchmarkDotNet=v0.10.1, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel Xeon E312xx (Sandy Bridge)Intel Xeon E312xx (Sandy Bridge)Intel Xeon E312xx (Sandy Bridge)Intel Xeon E312xx (Sandy Bridge), ProcessorCount=4
Frequency=3579545 Hz, Resolution=279.3651 ns, Timer=ACPI
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1055.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1055.0


```

```
              Method |          Mean |     StdErr |      StdDev |        Median | Scaled | Rank |  Gen 0 | Allocated |
-------------------- |-------------- |----------- |------------ |-------------- |------- |----- |------- |---------- |
        'GroBuf [S]' |   195.3938 ns |  1.0859 ns |   3.7615 ns |   197.0736 ns |   1.00 |    1 | 0.0896 |     196 B |
        'GroBuf [D]' |   273.0626 ns |  2.7629 ns |  18.1177 ns |   268.5053 ns |   1.40 |    2 | 0.0633 |     140 B |
 'Message shark [S]' |   346.2093 ns |  3.5296 ns |  25.2065 ns |   339.0342 ns |   1.77 |    3 | 0.1940 |     416 B |
 'Message shark [D]' |   369.2212 ns |  4.1442 ns |  15.5064 ns |   366.3836 ns |   1.89 |    4 | 0.0952 |     212 B |
       'MsgPack [S]' |   486.6688 ns |  4.9594 ns |  46.5231 ns |   477.3804 ns |   2.49 |    5 | 0.1899 |     420 B |
      'Protobuf [S]' |   543.8011 ns |  5.2836 ns |  28.9396 ns |   539.8172 ns |   2.78 |    6 | 0.1877 |     416 B |
           'Jil [S]' |   561.5007 ns |  5.5711 ns |  43.5119 ns |   555.8449 ns |   2.87 |    7 | 0.2146 |     468 B |
           'Jil [D]' |   595.3929 ns |  5.9715 ns |  52.7391 ns |   587.8291 ns |   3.05 |    8 | 0.1972 |     460 B |
       'MsgPack [D]' |   640.8954 ns |  6.3986 ns |  40.9711 ns |   632.9429 ns |   3.28 |    9 | 0.1201 |     268 B |
      'Protobuf [D]' |   806.0489 ns |  7.8555 ns |  40.8186 ns |   791.1105 ns |   4.13 |   10 | 0.0425 |     112 B |
          'Wire [S]' |   948.7948 ns |  9.3596 ns |  50.4028 ns |   939.9779 ns |   4.86 |   11 | 0.0717 |     168 B |
  'ServiceStack [S]' |   984.3173 ns |  9.8624 ns |  96.6315 ns |   949.1895 ns |   5.04 |   12 | 0.0734 |     168 B |
  'ServiceStack [D]' | 1,036.9087 ns | 11.0207 ns |  58.3163 ns | 1,034.4571 ns |   5.31 |   13 | 0.1230 |     284 B |
          'Wire [D]' | 1,045.8066 ns | 10.1991 ns |  40.7963 ns | 1,039.7236 ns |   5.35 |   13 | 0.1192 |     284 B |
     'Json .NET [S]' | 1,201.3188 ns | 11.9441 ns | 102.7474 ns | 1,171.7025 ns |   6.15 |   14 | 0.5464 |   1.18 kB |
          'Bson [S]' | 1,580.5473 ns | 15.7929 ns | 140.3707 ns | 1,540.1027 ns |   8.09 |   15 | 0.4943 |   1.11 kB |
     'FsPickler [D]' | 1,608.5046 ns | 15.7960 ns | 101.1441 ns | 1,606.8375 ns |   8.23 |   15 | 0.4007 |      1 kB |
     'FsPickler [S]' | 1,713.7830 ns | 17.1488 ns |  66.4171 ns | 1,703.7319 ns |   8.77 |   16 | 0.5725 |   1.25 kB |
          'Bson [D]' | 1,951.5804 ns | 19.5717 ns | 175.0548 ns | 1,911.9199 ns |   9.99 |   17 | 0.3136 |     700 B |
     'Json .NET [D]' | 1,958.1008 ns | 23.6180 ns | 234.9957 ns | 1,907.8817 ns |  10.02 |   17 | 1.1928 |   2.53 kB |
      'FastJson [S]' | 2,097.6430 ns | 20.8151 ns | 177.8441 ns | 2,031.2483 ns |  10.74 |   18 | 1.0620 |   2.27 kB |
      'FastJson [D]' | 3,438.7611 ns | 38.3502 ns | 383.5022 ns | 3,323.6520 ns |  17.61 |   19 | 0.6752 |   1.51 kB |
```

---
[Tiny value data](https://github.com/krezon/serializer-perf/blob/master/src/Models/TinyValueData.css)

``` ini

BenchmarkDotNet=v0.10.1, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel Xeon E312xx (Sandy Bridge)Intel Xeon E312xx (Sandy Bridge)Intel Xeon E312xx (Sandy Bridge)Intel Xeon E312xx (Sandy Bridge), ProcessorCount=4
Frequency=3579545 Hz, Resolution=279.3651 ns, Timer=ACPI
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1055.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1055.0


```

```
              Method |          Mean |     StdErr |      StdDev |        Median | Scaled | Rank |  Gen 0 | Allocated |
-------------------- |-------------- |----------- |------------ |-------------- |------- |----- |------- |---------- |
        'GroBuf [S]' |   217.2849 ns |  2.2307 ns |  19.5740 ns |   211.5419 ns |   1.00 |    1 | 0.0635 |     144 B |
 'Message shark [D]' |   237.7714 ns |  2.4036 ns |  19.8207 ns |   232.5318 ns |   1.10 |    2 | 0.0654 |     144 B |
        'GroBuf [D]' |   280.7566 ns |  2.8350 ns |  21.5904 ns |   276.8732 ns |   1.30 |    3 | 0.0201 |      56 B |
 'Message shark [S]' |   286.6776 ns |  2.8958 ns |  21.2797 ns |   285.9343 ns |   1.33 |    3 | 0.1927 |     412 B |
           'Jil [D]' |   405.4818 ns |  4.0597 ns |  25.9945 ns |   398.3571 ns |   1.88 |    4 | 0.0474 |     108 B |
       'MsgPack [S]' |   430.2149 ns |  4.3168 ns |  39.7991 ns |   425.2952 ns |   1.99 |    5 | 0.1707 |     368 B |
      'Protobuf [S]' |   519.5098 ns |  5.4716 ns |  44.1135 ns |   516.9045 ns |   2.41 |    6 | 0.1731 |     416 B |
           'Jil [S]' |   628.7990 ns |  6.2019 ns |  39.7116 ns |   626.2244 ns |   2.92 |    7 | 0.1464 |     324 B |
      'Protobuf [D]' |   649.0385 ns |  6.5084 ns |  60.0045 ns |   640.5212 ns |   3.01 |    8 | 0.0075 |      28 B |
       'MsgPack [D]' |   674.4687 ns |  7.5058 ns |  37.5292 ns |   671.1500 ns |   3.13 |    9 | 0.0529 |     132 B |
          'Wire [D]' | 1,572.5428 ns | 15.6256 ns |  85.5851 ns | 1,549.9745 ns |   7.29 |   10 | 0.0858 |     224 B |
  'ServiceStack [D]' | 1,575.0625 ns | 15.7042 ns | 107.6623 ns | 1,552.2528 ns |   7.30 |   10 | 0.0905 |     224 B |
     'FsPickler [D]' | 1,656.3458 ns | 16.5466 ns | 156.9749 ns | 1,604.5014 ns |   7.68 |   11 | 0.4198 |     928 B |
  'ServiceStack [S]' | 1,762.8275 ns | 17.1074 ns |  64.0101 ns | 1,750.2919 ns |   8.17 |   12 | 0.0758 |     260 B |
          'Wire [S]' | 1,781.4106 ns | 17.7581 ns | 154.8112 ns | 1,740.6193 ns |   8.26 |   12 | 0.0880 |     260 B |
     'FsPickler [S]' | 1,890.8890 ns | 18.7074 ns | 139.9934 ns | 1,863.8834 ns |   8.77 |   13 | 0.5693 |   1.25 kB |
          'Bson [S]' | 1,893.5297 ns | 21.4209 ns | 152.9760 ns | 1,850.8955 ns |   8.78 |   13 | 0.5881 |   1.27 kB |
     'Json .NET [S]' | 1,899.6320 ns | 18.8750 ns | 123.7714 ns | 1,878.8944 ns |   8.81 |   13 | 0.5558 |   1.21 kB |
          'Bson [D]' | 2,493.3373 ns | 25.8184 ns | 232.3657 ns | 2,403.3000 ns |  11.56 |   14 | 0.2324 |     696 B |
      'FastJson [S]' | 2,590.2210 ns | 25.8791 ns | 173.6021 ns | 2,568.3258 ns |  12.01 |   15 | 1.0247 |    2.2 kB |
     'Json .NET [D]' | 2,778.9912 ns | 50.3585 ns | 195.0375 ns | 2,721.8970 ns |  12.89 |   16 | 1.1832 |   2.55 kB |
      'FastJson [D]' | 4,331.4588 ns | 33.8073 ns | 130.9353 ns | 4,293.8620 ns |  20.09 |   17 | 0.6755 |   1.57 kB |
```
