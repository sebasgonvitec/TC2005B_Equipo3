import {Chart, registerables} from '/scripts/charts/chart.esm.js'
Chart.register(...registerables);

/**
 * @param {number} alpha Indicated the transparency of the color
 * @returns {string} A string of the form 'rgba(240, 50, 123, 1.0)' that represents a color
 */
function random_color(alpha=1.0)
{
    const r_c = () => Math.round(Math.random() * 255)
    return `rgba(${r_c()}, ${r_c()}, ${r_c()}, ${alpha}`
}

// To plot data from an API, we first need to fetch a request, and then process the data.
// Graph 1
try {
    const user_log_view = await fetch('http://localhost:5000/api/userLogView/g1',{
        method: 'GET'
    })

    console.log('Got a response correctly')

    if(user_log_view.ok) {
        console.log('Response is ok. Converting to JSON.')

        let results = await user_log_view.json()

        console.log('Data converted correctly. Plotting chart.')
        
        const values = Object.values(results)
        const log_username = values.map(e => e['username'])
        const level_colors = values.map(e => random_color(0.8))
        const logged_times = values.map(e => e['times_login'])

        const ctx_levels = document.getElementById('firstChart').getContext('2d');
        const levelChart = new Chart(ctx_levels, 
            {
                type: 'bar',
                data: {
                    labels: log_username,
                    datasets: [
                        {
                            label: 'Most Active Users',
                            data: logged_times,
                            backgroundColor: [
                                'rgba(255, 99, 132, 0.2)',
                                'rgba(54, 162, 235, 0.2)',
                                'rgba(255, 206, 86, 0.2)',
                                'rgba(75, 192, 192, 0.2)',
                                'rgba(153, 102, 255, 0.2)',
                                'rgba(255, 159, 64, 0.2)'
                            ],
                            borderColor: [
                                'rgba(255, 99, 132, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(255, 206, 86, 1)',
                                'rgba(75, 192, 192, 1)',
                                'rgba(153, 102, 255, 1)',
                                'rgba(255, 159, 64, 1)'
                            ],
                            borderWidth: 1
                        }
                    ]
                },
                
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            })

    }
}
catch(error) {
    console.log(error)
}

// Graph 2
try {
    const connections_view = await fetch('http://localhost:5000/api/userLogView/g2',{
        method: 'GET'
    })

    console.log('Got a response correctly')

    if(connections_view.ok) {
        console.log('Response is ok. Converting to JSON.')

        let results = await connections_view.json()

        console.log('Data converted correctly. Plotting chart.')
        
        const values = Object.values(results)
        const con_username = values.map(e => e['username'])
        const level_colors = values.map(e => random_color(0.8))
        const first_c = values.map(e => e['first_connection'])
        const last_c = values.map(e => e['last_connection'])

        const ctx_levels = document.getElementById('secondChart').getContext('2d');
        const levelChart = new Chart(ctx_levels, 
            {
                type: 'bar',
                data: {
                    labels: con_username,
                    datasets: [
                        {
                            label: 'Timeline of Users Connections',
                            data: [first_c, last_c],
                            backgroundColor: [
                                'rgba(255, 99, 132, 0.2)',
                                'rgba(54, 162, 235, 0.2)',
                                'rgba(255, 206, 86, 0.2)',
                                'rgba(75, 192, 192, 0.2)',
                                'rgba(153, 102, 255, 0.2)',
                                'rgba(255, 159, 64, 0.2)'
                            ],
                            borderColor: [
                                'rgba(255, 99, 132, 1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(255, 206, 86, 1)',
                                'rgba(75, 192, 192, 1)',
                                'rgba(153, 102, 255, 1)',
                                'rgba(255, 159, 64, 1)'
                            ],
                            barPercentage: 0.2
                        }
                    ]
                },

                options: {
                    indexAxis: 'y',
                    scales: {
                        x: {
                            min: '2022-05-15',
                            type: 'time',
                            time: {
                                unit: 'day'
                            }
                        },
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            })

    }
}
catch(error) {
    console.log(error)
}

// We obtain a reference to the canvas that we are going to use to plot the chart.
/* const ctx = document.getElementById('firstChart').getContext('2d');

// To plot a chart, we need a configuration object that has all the information that the chart needs.
const firstChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
        datasets: [{
            label: '# of Votes',
            data: [12, 19, 3, 5, 2, 3],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 159, 64, 0.2)'
            ],
            borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
}); */

// Gráfica 3
try
{
    const user_view = await fetch('http://localhost:5000/api/userView',{
        method: 'GET'
    })

    console.log('Got a response correctly')

    if(user_view.ok)
    {
        console.log('Response is ok. Converting to JSON.')

        let results = await user_view.json()

        console.log('Data converted correctly. Plotting chart.')
        
        const values = Object.values(results)

        // In this case, we just separate the data into different arrays using the map method of the values array. This creates new arrays that hold only the data that we need.
        const level_username = values.map(e => e['username'])
        const level_colors = values.map(e => random_color(0.8))
        const level_created = values.map(e => e['num_levels_created'])

        const ctx_levels = document.getElementById('apiChart').getContext('2d');
        const levelChart = new Chart(ctx_levels, 
            {
                type: 'pie',
                data: {
                    labels: level_username,
                    datasets: [
                        {
                            label: 'Levels Created',
                            backgroundColor: level_colors,
                            data: level_created
                        }
                    ]
                }
            })
    }
}
catch(error)
{
    console.log(error)
}