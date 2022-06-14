//import {Chart, registerables} from '/scripts/charts/chart.esm.js'
//Chart.register(...registerables);

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
                             label: 'Login Times',
                             data: logged_times,
                             backgroundColor: [
                                 'rgba(143, 74, 138, 0.8)',
                                 'rgba(74,31,71,0.8)',
                                 'rgba(184, 105, 157, 0.8)',
                                 'rgba(212, 125, 162, 0.8)',
                                 'rgba(92, 78, 166, 0.8)',
                                 'rgba(32, 26, 64, 0.8)',
                                 'rgba(209, 113, 187, 0.8)',
                                 'rgba(188, 104, 134, 0.8)',
                                 'rgba(209, 92, 149, 0.8)'
                             ],
                             borderColor: [
                                'rgba(143, 74, 138, 1)',
                                'rgba(74,31,71,1)',
                                'rgba(184, 105, 157, 1)',
                                'rgba(212, 125, 162, 1)',
                                'rgba(92, 78, 166, 1)',
                                'rgba(32, 26, 64, 1)',
                                'rgba(209, 113, 187, 1)',
                                'rgba(188, 104, 134, 1)',
                                'rgba(209, 92, 149, 0.8)'
                             ],
                             borderWidth: 1
                         }
                     ]
                 },
                 
                 options: {
                     scales: {
                         y: {
                             beginAtZero: true,
                             title: {
                                display: true,
                                text: 'Total Times the User Logged In'//Name of Y axis 
                            }   
                         },

                         x: {
                            beginAtZero: true,
                            title: {
                               display: true,
                               text: 'Username'//Name of Y axis 
                           }   
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
     console.log('Got a response correctly for second chart')
     if(connections_view.ok)
     {
         console.log('Response is ok. Converting to JSON.')
         let results = await connections_view.json()
         console.log('Data converted correctly. Plotting chart.')
         
         const values = Object.values(results)
         const con_username = values.map(e => e['username'])
         const first_c = values.map(e => e['first_connection'])
         const last_c = values.map(e => e['last_connection'])
         const dates = values.map(e => [e['first_connection'], e['last_connection']])
         console.log('s', first_c, last_c, dates)
         const ctx_levels = document.getElementById('secondChart').getContext('2d');
         const levelChart = new Chart(ctx_levels,
             {
                 type: 'bar',
                 data: {
                     labels: con_username,
                     datasets: [
                         {
                             label: 'Timeline of Users Connections',
                             data: dates,
                             backgroundColor: [
                                'rgba(143, 74, 138, 1)',
                                'rgba(74,31,71,1)',
                                'rgba(184, 105, 157, 1)',
                                'rgba(212, 125, 162, 1)',
                                'rgba(92, 78, 166, 1)',
                                'rgba(32, 26, 64, 1)',
                                'rgba(209, 113, 187, 1)',
                                'rgba(188, 104, 134, 1)',
                                'rgba(209, 92, 149, 1)'
                             ],
                             borderColor: [
                                'rgba(143, 74, 138, 1)',
                                'rgba(74,31,71,1)',
                                'rgba(184, 105, 157, 1)',
                                'rgba(212, 125, 162, 1)',
                                'rgba(92, 78, 166, 1)',
                                'rgba(32, 26, 64, 1)',
                                'rgba(209, 113, 187, 1)',
                                'rgba(188, 104, 134, 1)',
                                'rgba(209, 92, 149, 0.8)'
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
                             title: {
                                display: true,
                                text: 'Range from first to last connection'//Name of Y axis 
                            },   
                            time: {
                                unit: 'day'
                            }
                         },
                         y: {
                             beginAtZero: true,
                             title: {
                                display: true,
                                text: 'Username'//Name of Y axis 
                            }
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
        //  const level_colors = values.map(e => random_color(0.8))
         const level_created = values.map(e => e['num_levels_created'])
 
         const ctx_levels = document.getElementById('apiChart').getContext('2d');
         const levelChart = new Chart(ctx_levels, 
             {
                 type: 'doughnut',
                 data: {
                     labels: level_username,
                     datasets: [
                         {
                             label: 'Levels Created by Each User',
                             backgroundColor: [
                                'rgba(143, 74, 138, 1)',
                                'rgba(92, 78, 166, 1)',
                                'rgba(212, 125, 162, 1)',
                                'rgba(74,31,71,1)',
                                'rgba(184, 105, 157, 1)',
                                'rgba(32, 26, 64, 1)',
                                'rgba(209, 113, 187, 1)',
                                'rgba(188, 104, 134, 1)',
                                'rgba(209, 92, 149, 1)'
                             ],
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
         console.log(times_played)
 
         const ctx_levels = document.getElementById('thirdChart').getContext('2d');
         
         const levelChart = new Chart(ctx_levels, 
             {
                 type: 'bar',
                 data: {
                     labels: level_name,
                     datasets: [
                         {
                             label: 'Most Played Levels',
                             data: times_played,
                             backgroundColor: [
                                'rgba(143, 74, 138, 1)',
                                'rgba(74,31,71,1)',
                                'rgba(184, 105, 157, 1)',
                                'rgba(212, 125, 162, 1)',
                                'rgba(92, 78, 166, 1)',
                                'rgba(32, 26, 64, 1)',
                                'rgba(209, 113, 187, 1)',
                                'rgba(188, 104, 134, 1)',
                                'rgba(209, 92, 149, 1)'
                             ],
                             borderColor: [
                                'rgba(143, 74, 138, 1)',
                                'rgba(74,31,71,1)',
                                'rgba(184, 105, 157, 1)',
                                'rgba(212, 125, 162, 1)',
                                'rgba(92, 78, 166, 1)',
                                'rgba(32, 26, 64, 1)',
                                'rgba(209, 113, 187, 1)',
                                'rgba(188, 104, 134, 1)',
                                'rgba(209, 92, 149, 0.8)'
                             ],
                             borderWidth: 1
                         }
                     ]
                 },
 
                 options: {
                    scales: {
                        y: {
                            beginAtZero: true,
                            title: {
                               display: true,
                               text: 'Number of Times Played'//Name of Y axis 
                           }   
                        },

                        x: {
                           beginAtZero: true,
                           title: {
                              display: true,
                              text: 'Level Name'//Name of Y axis 
                          }   
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
 
 let level_name_list = [] //global variable to store level name lists
 // Drop Down List 
 try {
     const level_names_form = await fetch('http://localhost:5000/api/LevelTimesView/levelNameForm',{
         method: 'GET'
     })
 
     console.log('Got a response correctly')
 
     if(level_names_form.ok) {
         console.log('Response is ok. Converting to JSON.')
 
         let results = await level_names_form.json()
         console.log(results)
 
         console.log('Data converted correctly. Plotting selector.')
         
         const values = Object.values(results)
         const level_name = values.map(e => e['level_name']) 
         level_name_list = level_name
 
         let select = document.getElementById("levels")
 
         for(let i=0; i<level_name.length; i++) {
             let opt = level_name[i]
             let element = document.createElement("option")
             element.textContent = opt
             element.value = opt
             select.appendChild(element)
         }
     }
 }
 catch(error) {
     console.log(error)
 }
 
 // Graph 5: The best 5 times by levels (a drop down will be use but at the moment a string is used)
 // revisar esto
//  levels.addEventListener('change', timesByLevel)
//  function timesByLevel() {
//     //  let selected = document.getElementById("levels").value;
//     //  return selected
//     console.log("HOLAAAAAA")

//  }

// function timesByLevel() 
// {
//     //let selected = document.getElementById("levels").value;
//     console.log("HOLAAAAAA")
//     //console.log(selected)
//     //return selected
// }
 
 try { 

    let results_arr = [] // array with each level data (json)
     
    // Get corresponding data for each level and store in array
    for(let i=0; i<level_name_list.length; i++) 
    {
        const times_by_level_view = await fetch('http://localhost:5000/api/LevelTimesView/' + level_name_list[i], {method: 'GET'})
        
        if(times_by_level_view.ok) 
        {
            let results = await times_by_level_view.json()
            results_arr.push(results)
        }
    }

    //console.log(results_arr)  
    let levelChart = null; 

    levels.addEventListener('change', timesByLevel)
    function timesByLevel() 
    {
        //get selected level
        let selected = document.getElementById("levels").value;
        let values;
        let username;
        let time_elapsed;

        //If the chart canvas was already created, destroy 
        if(levelChart != null)
        {
            levelChart.destroy();
        }

        for(let i=0; i<level_name_list.length; i++) 
        {
            //Only if current data is the same as selected, save relevant data for the graph
            if(selected == level_name_list[i])
            {
                values = Object.values(results_arr[i])
                username = values.map(e => e['username']) 
                time_elapsed = values.map(e => e['time_elapsed'])
                break
            }
        }

        //Graph section
        const ctx_levels = document.getElementById('fourthChart').getContext('2d');
 
        levelChart = new Chart(ctx_levels, 
             {
                 type: 'bar',
                 data: {
                     labels: username,
                     datasets: [
                         {
                             label: 'The best 5 times by levels',
                             data: time_elapsed,
                             backgroundColor: [
                                'rgba(143, 74, 138, 1)',
                                'rgba(74,31,71,1)',
                                'rgba(184, 105, 157, 1)',
                                'rgba(212, 125, 162, 1)',
                                'rgba(92, 78, 166, 1)',
                                'rgba(32, 26, 64, 1)',
                                'rgba(209, 113, 187, 1)',
                                'rgba(188, 104, 134, 1)',
                                'rgba(209, 92, 149, 1)'
                             ],
                             borderColor: [
                                'rgba(143, 74, 138, 1)',
                                'rgba(74,31,71,1)',
                                'rgba(184, 105, 157, 1)',
                                'rgba(212, 125, 162, 1)',
                                'rgba(92, 78, 166, 1)',
                                'rgba(32, 26, 64, 1)',
                                'rgba(209, 113, 187, 1)',
                                'rgba(188, 104, 134, 1)',
                                'rgba(209, 92, 149, 0.8)'
                             ],
                             borderWidth: 1
                         }
                     ]
                 },
 
                 options: {
                    scales: {
                        y: {
                            beginAtZero: true,
                            title: {
                               display: true,
                               text: 'Time in Seconds'//Name of Y axis 
                           }   
                        },

                        x: {
                           beginAtZero: true,
                           title: {
                              display: true,
                              text: 'Username'//Name of Y axis 
                          }   
                       }
                    }
                 }
             })   
    }
 }
 catch(error) {
     console.log(error)
 }

