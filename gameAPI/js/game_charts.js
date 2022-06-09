import {Chart, registerables} from '/scripts/charts/chart.esm.js'
import {toDate} from '/scripts/charts/chartjs-adapter-date-fns.esm.js'
Chart.register(...registerables);
//import { timeStamp } from 'console';

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
// Graph 1: Bar Chart, User log view. The 10 most active users
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

// Graph 2: Timeline Chart, User log view. First and Last Connection of each user
// ESTA ES LA GRÁFICA QUE NECESITA EL DATE-FNS DEL PROBLEMA 
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
                            data: [toDate(first_c), toDate(last_c)],
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

// Graph 3: Pie Chart, User View. The percentage of levels each user has created 
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
                type: 'doughnut',
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

// Graph 4: Bar Chart, Times levels view. The 10 most played levels
// top labels pluggin block

try {
    const levels_played_view = await fetch('http://localhost:5000/api/timesLevelView',{
        method: 'GET'
    })

    console.log('Got a response correctly')

    if(levels_played_view.ok) {
        console.log('Response is ok. Converting to JSON.')

        let results = await levels_played_view.json()

        console.log('Data converted correctly. Plotting chart.')
        
        const values = Object.values(results)
        const level_username = values.map(e => e['username']) 
        const level_name = values.map(e => e['level_name'])
        const times_played = values.map(e => e['times_played'])
    
        /* const topLabels {
            id: 'topLabels',
            afterDatasetsDraw(chart, args, pluginOptions) {
                const { ctx, scales: {x, y} } = chart;
                ctx.font = 'bold 12px sans-serif';
                ctx.fillStyle = black;
                ctx.textAlign = 'center';
                ctx.fillText(level_username, x.getPixelForValue(), )
            }
        } */

        console.log(times_played)

        const ctx_levels = document.getElementById('thirdChart').getContext('2d');
        
        const levelChart = new Chart(ctx_levels, 
            {
                type: 'bar',
                data: {
                    labels: level_name,
                    datasets: [
                        {
                            label: 'Timeline of Users Connections',
                            data: [times_played],
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
                },

                //plugins: [topLabels]
            })

    }
}
catch(error) {
    console.log(error)
}

// Graph 5: The best 5 times by levels (a drop down will be use but at the moment a string is used)
// revisar esto
try {
    const times_by_level_view = await fetch('http://localhost:5000/api/LevelTimesView/:levelName',{
        method: 'GET'
    })

    console.log('Got a response correctly')

    if(times_by_level_view.ok) {
        console.log('Response is ok. Converting to JSON.')

        let results = await times_by_level_view.json()

        console.log('Data converted correctly. Plotting chart.')
        
        const values = Object.values(results)
        const username = values.map(e => e['username']) 
        const time_elapsed = values.map(e => e['time_elapsed'])

        const ctx_levels = document.getElementById('fourthChart').getContext('2d');
        const levelChart = new Chart(ctx_levels, 
            {
                type: 'bar',
                data: {
                    labels: username,
                    datasets: [
                        {
                            label: 'The best 5 times by levels',
                            data: [time_elapsed],
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