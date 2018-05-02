# Current state of mono-wasm/Blazor performance

## Benchmark Information

The Benchmark is currently very simple and only does the following things:

* Generate 100,000 random list elements (from 0.0 to 1.0)
* Sort the list by their values
* Get Q1, Median, Q3 and calculate average and standard deviation

## Platform Information

The Benchmark was implemented in the following languages/platforms:

* .NET Core 2.1.300 (preview2-008533)
* mono-wasm (commit a14f41c from Blazor 0.2.0)
* C (gcc 4.2.1)
* C-wasm (emcc 1.37.36)
* JavaScript (TypeScript 2.8.1)

The .NET Projects where build with `Release` configuration and the C Projects with `-O3` optimizations.

## Results

|           | C      | C.Wasm   | DotNet.Console   | DotNet.Wasm   | JavaScript   |
|-----------|-------:|---------:|-----------------:|--------------:|-------------:|
| Generate  | 1.21ms |   1.00ms |           1.00ms |      127.00ms |       7.50ms |
| Sort      | 9.05ms |  12.00ms |          26.00ms |     7123.00ms |      22.40ms |
| Calculate | 0.21ms |   1.00ms |           4.00ms |      498.00ms |       6.60ms |

![Benchmark Chart](images/benchmark-20180502.PNG?raw=true "Benchmark Chart")