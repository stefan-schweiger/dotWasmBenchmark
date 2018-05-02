
function run() {
    console.log("Start");

    const worker = new Worker('./Program.js');

    worker.postMessage('start');

    worker.addEventListener('message', function (e) {
        var data = JSON.parse(e.data);

        if (data.message === 'generated') {
            console.log(`Generate:  ${data.duration.toFixed(2)}ms`);
        }
        else if (data.message === 'matched') {
            console.log(`Match      ${data.duration.toFixed(2)}ms`);
        }
        else if (data.message === 'sorted') {
            console.log(`Sort:      ${data.duration.toFixed(2)}ms`);
        } else if (data.message === 'calculated') {
            console.log(`Calculate: ${data.duration.toFixed(2)}ms`);

            console.log("----------------------------------------------");

            console.log(`Q1     ${data.result.q1.toFixed(5)}`);
            console.log(`Median ${data.result.median.toFixed(5)}`);
            console.log(`Q3     ${data.result.q3.toFixed(5)}`);
            console.log(`Avg.   ${data.result.avg.toFixed(5)}`);
            console.log(`StDev. ${data.result.stDev.toFixed(5)}`);
        }
    }, false);
}