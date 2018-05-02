importScripts(
    './DNAGenerator.js',
    './Sequencer.js',
    './Sort.js',
    './Calc.js',
    './Stopwatch.js'
);

self.addEventListener('message', function(e) {
    const sw = new StopWatch();

    const n = 100000;
    const list = [];

    sw.start();
    //const seq = DNAGenerator.generate(100000, 500);
    for (let i = 0; i < n; i++) {
        list[i] = Math.random();
    }
    sw.stop();

    self.postMessage(
        JSON.stringify({ message: 'generated', duration: sw.elapsed })
    );

    //sw.start();
    //const list = Sequencer.sequenceMatch(seq);
    //sw.stop();

    //self.postMessage(
    //    JSON.stringify({ message: 'matched', duration: sw.elapsed })
    //);

    sw.start();
    Sort.quickSort(list);
    sw.stop();

    self.postMessage(
        JSON.stringify({ message: 'sorted', duration: sw.elapsed })
    );

    sw.start();
    const res = Calc.calculate(list);
    sw.stop();

    self.postMessage(
        JSON.stringify({ message: 'calculated', duration: sw.elapsed, result: res })
    );

    self.close();
}, false);