mkdir out
emcc -O3 ./main.c -o out/index.html -s WASM=1 -s ALLOW_MEMORY_GROWTH=1