
function run() {
    console.log("Start");

    const worker = new Worker('./Program.js');

    worker.postMessage('start');

    worker.addEventListener('message', function (e) {
        var data = JSON.parse(e.data);

        console.log(`Generate:  ${data.generate.toFixed(2)}ms`);
        //console.log(`Match      ${data.duration.toFixed(2)}ms`);
        console.log(`Sort:      ${data.sort.toFixed(2)}ms`);
        console.log(`Calculate: ${data.calculate.toFixed(2)}ms`);

        console.log("----------------------------------------------");

        console.log(`Q1     ${data.calcResult.q1.toFixed(5)}`);
        console.log(`Median ${data.calcResult.median.toFixed(5)}`);
        console.log(`Q3     ${data.calcResult.q3.toFixed(5)}`);
        console.log(`Avg.   ${data.calcResult.avg.toFixed(5)}`);
        console.log(`StDev. ${data.calcResult.stDev.toFixed(5)}`);
    }, false);
}