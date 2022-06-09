"use strict"

import express from 'express'
import mysql from 'mysql2/promise'
import fs from 'fs'

const app = express()
const port = 5000

app.use(express.json())

app.use('/scripts/charts', express.static('./node_modules/chart.js/dist/'))
app.use('/scripts/charts', express.static('./node_modules/chartjs-adapter-date-fns/dist'))
app.use('/js', express.static('./js'))
app.use('/css', express.static('./css'))

//Create connection to database
async function connectToDB()
{
    return await mysql.createConnection({
        host:'localhost',
        user:'AsleepDevelop',
        password:'quieroamiT0p0',
        database:'asleep_db'
    })
}

// Get root page (main crud html)
app.get('/', (request,response)=>{
    fs.readFile('./html/charts.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err)
        console.log('Loading page...')
        response.send(html)
    })
})

// USERS TABLE --------------------------------------------------------------------------------

//Get a user from specific username
app.get('/api/users/log/:username', async (request, response)=>
{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.query('select * from users where username= ?', [request.params.username])
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})



//Post for users table
app.post('/api/users', async (request, response)=>{

    let connection = null

    try
    {    
        connection = await connectToDB()
        const [results, fields] = await connection.query('insert into users set ?', request.body)
        response.json({'message': "Data inserted correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


// Put/Update for users table
app.put('/api/users', async (request, response)=>{

    let connection = null

    try{
        connection = await connectToDB()
        const [results, fields] = await connection.query('update users set username= ?, user_password= ?, num_levels_created= ?, first_connection= ?, last_connection= ?, times_login= ? where id_user= ?', 
        [request.body['username'], 
        request.body['user_password'],
        request.body['num_levels_created'], 
        request.body['first_connection'],
        request.body['last_connection'],
        request.body['times_login'],
        request.body['id_user']])

        response.json({'message': "Data updated correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

// LEVEL TABLE ------------------------------------------------------------------------
// get level table 
app.get('/api/levels', async (request, response)=>{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from levels')
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

//Get a level from specific id 
app.get('/api/levels/:id', async (request, response)=>
{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.query('select * from levels where id_level= ?', [request.params.id])
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

//Post for levels table
app.post('/api/levels', async (request, response)=>{

    let connection = null

    try
    {    
        connection = await connectToDB()
        const [results, fields] = await connection.query('insert into levels set ?', request.body)
        response.json({'message': "Data inserted correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


// Put/Update for levels table
app.put('/api/levels', async (request, response)=>{

    let connection = null

    try{
        connection = await connectToDB()
        const [results, fields] = await connection.query('update levels set id_user= ?, level_name= ?, level_file= ?, level_time= ?, num_items= ?, times_played= ?, date_created= ? where id_level= ?', 
        [request.body['id_user'], 
        request.body['level_name'],
        request.body['level_file'], 
        request.body['level_time'],
        request.body['num_items'],
        request.body['times_played'],
        request.body['date_created'],
        request.body['id_level']])

        response.json({'message': "Data updated correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


// GAMEPLAY TABLE ------------------------------------------------------------------------

//get gamplay table 
app.get('/api/gameplays', async (request, response)=>{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from gameplays')
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

//Get a level from specific id 
app.get('/api/gameplays/:id', async (request, response)=>
{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.query('select * from gameplays where id_gameplay= ?', [request.params.id])
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

//Post for levels table
app.post('/api/gameplays', async (request, response)=>{

    let connection = null

    try
    {    
        connection = await connectToDB()
        const [results, fields] = await connection.query('insert into gameplays set ?', request.body)
        response.json({'message': "Data inserted correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


// Put/Update for levels table
app.put('/api/gameplays', async (request, response)=>{

    let connection = null

    try{
        connection = await connectToDB()
        const [results, fields] = await connection.query('update gameplays set id_user= ?, id_level= ?, time_elapsed= ? where id_gameplay= ?', 
        [request.body['id_user'], 
        request.body['id_level'],
        request.body['time_elapsed'],
        request.body['id_gameplay']])

        response.json({'message': "Data updated correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})



// VIEWS /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//Get levels_view (UNITY)
app.get('/api/levelsview', async (request, response)=>
{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.query('select * from levels_view')
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


// user_log View -> Select para Grafica 1
app.get('/api/userLogView/g1', async (request, response)=>
{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.query('SELECT username, times_login FROM user_log')
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


// user_log View -> Select para Grafica 2
app.get('/api/userLogView/g2', async (request, response)=>
{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.query('SELECT username, first_connection, last_connection FROM user_log')
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


// user_view View -> Select para Grafica 3
app.get('/api/userView', async (request, response)=>
{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.query('SELECT * FROM user_view')
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


// times_level View -> Select para Grafica 4
app.get('/api/timesLevelView', async (request, response)=>
{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.query('SELECT * FROM times_level')
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


// level_times View -> Select para Grafica 5
app.get('/api/LevelTimesView/:levelName', async (request, response)=>
{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.query('SELECT * FROM level_times WHERE level_name = ? LIMIT 5;', [request.params.levelName])
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})



// STORED PROCEDURES //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//Call stored procedure to increase number of times played of a certain level (UNITY)
app.get('/api/levels/sp/timesPlayed/:id_level', async (request, response)=>{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('CALL num_timesPlayed (?)',  [request.params.id_level])
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

// Call stored procedure to update last connection of a given user (UNITY)
app.get('/api/users/sp/lastConnection/:id_user', async (request, response)=>{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('CALL updt_lastConnection (?)',  [request.params.id_user])
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


// Call stored procedure to update login count of a given user (UNITY)
app.get('/api/users/sp/logTimes/:id_user', async (request, response)=>{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('CALL updt_logTimes (?)',  [request.params.id_user])
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


// Call stored procedure to update the number of levels created of a given user (UNITY)
app.get('/api/users/sp/levelsCreated/:id_user', async (request, response)=>{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('CALL updt_createdLevels (?)',  [request.params.id_user])
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})



app.listen(port, ()=>
{
    console.log(`App listening at http://localhost:${port}`)
})