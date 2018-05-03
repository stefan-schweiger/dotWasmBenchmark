importScripts(
    './DNAGenerator.js',
    './Sequencer.js',
    './Sort.js',
    './Calc.js',
    './Stopwatch.js'
);

function benchmark(n, length) {
    const sw = new StopWatch();
    
    const list = [];
    const res = {
        generate: 0,
        sort: 0,
        calculate: 0,
        calcResult: null
    };

    sw.start();
    //const seq = DNAGenerator.generate(100000, 500);
    for (let i = 0; i < n; i++) {
        list[i] = Math.random();
    }
    sw.stop();

    res.generate = sw.elapsed;

    //sw.start();
    //const list = Sequencer.sequenceMatch(seq);
    //sw.stop();

    //self.postMessage(
    //    JSON.stringify({ message: 'matched', duration: sw.elapsed })
    //);

    sw.start();
    Sort.quickSort(list);
    sw.stop();

    res.sort = sw.elapsed;

    sw.start();
    const calcRes = Calc.calculate(list);
    sw.stop();

    res.calculate = sw.elapsed;
    res.calcResult = calcRes;

    return res;
}

self.addEventListener('message', function(e) {
    const n = 5000000;

    const res = benchmark(n);

    self.postMessage(
        JSON.stringify(res)
    );

    self.close();
}, false);