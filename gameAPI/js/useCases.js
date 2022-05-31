function main()
{
    // USERS TABLE -----------------------------------------------------------------------------------------------------
    // Select 
    document.getElementById('formSelectUser').onsubmit = async (e) =>
    {
        e.preventDefault() //prevent automatic page reload

        const data = new FormData(formSelectUser)
        const dataObj = Object.fromEntries(data.entries()) // get entries section from data obj (which contains the actual info)

        let response = await fetch(`http://localhost:5000/api/users/${dataObj['id_user']}`,{
            method: 'GET'
        })
        
        if(response.ok)
        {
            let results = await response.json() // saved fetched info as json
        
            //Generate table
            if(results.length > 0)
            {
                //Get table headers and values
                const headers = Object.keys(results[0]) //headers can be obtained from the first entry
                const values = Object.values(results)
    
                let table = document.createElement("table") //create table element
    
                let tr = table.insertRow(-1) //insert new row at last position               
    
                // For each header create a table header
                for(const header of headers)
                {
                    let th = document.createElement("th")     
                    th.innerHTML = header
                    tr.appendChild(th)
                }
    
                // Iterate each entry in values
                for(const row of values)
                {
                    let tr = table.insertRow(-1) // insert new row at last position for the current entry 
    
                    // for the current row, iterate over each key/header and insert its corresponding value into a cell
                    for(const key of Object.keys(row))
                    {
                        let tabCell = tr.insertCell(-1) //insert a cell at last position
                        tabCell.innerHTML = row[key] // insert the corresponding value given the key
                    }
                }
                
                // Append table to result element
                const container = document.getElementById('getResultsIDUser')
                container.innerHTML = ''
                container.appendChild(table)
            }
            else
            {
                //Display message when no information was retrieved
                const container = document.getElementById('getResultsIDUser')
                container.innerHTML = 'No results to show.'
            }
        }
        else{
            getResults.innerHTML = response.status
        }
    }



    // Insert/Post
    document.getElementById('formInsertUser').onsubmit = async(e)=>
    {
        e.preventDefault() //prevent automatic page reload

        const data = new FormData(formInsertUser)
        const dataObj = Object.fromEntries(data.entries())

        let response = await fetch('http://localhost:5000/api/users',{
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(dataObj)
        })
        
        if(response.ok)
        {
            let results = await response.json() //save api response as json
            console.log(results)
            postResultsUser.innerHTML = results.message // display result in id=postResults element
        }
        else{
            postResultsUser.innerHTML = response.status //if response wasn't status 200 display status
        }
    }

    // Put/Update
    document.getElementById('formUpdateUser').onsubmit = async(e)=>
    {
        e.preventDefault() //prevent automatic page reload

        const data = new FormData(formUpdateUser)
        const dataObj = Object.fromEntries(data.entries())

        let response = await fetch('http://localhost:5000/api/users',{
            method: 'PUT',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(dataObj)
        })
        
        if(response.ok)
        {
            let results = await response.json() //save api response as json
        
            console.log(results)
            putResultsUser.innerHTML = results.message // display result in id=putResults element
        }
        else{
            putResultsUser.innerHTML = response.status //if response wasn't status 200 display status
        }
    }

    // Delete
    document.getElementById('formDeleteUser').onsubmit = async(e)=>
    {
        e.preventDefault() //prevent automatic page reload

        const data = new FormData(formDeleteUser)
        const dataObj = Object.fromEntries(data.entries())

        let response = await fetch(`http://localhost:5000/api/users/${dataObj['id_user']}`,{
            method: 'DELETE'
        })
        
        if(response.ok)
        {
            let results = await response.json() //save api response as json
            deleteResultsUser.innerHTML = results.message // display result in id=deleteResults element
        }
        else
        {
            //if response wasn't status 200 display error message with status
            deleteResultsUser.innerHTML = `Error!\nStatus: ${response.status} Message: ${results.message}`
        }
    }



    // LEVELS TABLE -----------------------------------------------------------------------------------------------------
    // Select 
    document.getElementById('formSelectLevels').onsubmit = async (e) =>
    {
        e.preventDefault() //prevent automatic page reload

        const data = new FormData(formSelectLevels)
        const dataObj = Object.fromEntries(data.entries()) // get entries section from data obj (which contains the actual info)

        let response = await fetch(`http://localhost:5000/api/levels/${dataObj['id_level']}`,{
            method: 'GET'
        })
        
        if(response.ok)
        {
            let results = await response.json() // saved fetched info as json
        
            //Generate table
            if(results.length > 0)
            {
                //Get table headers and values
                const headers = Object.keys(results[0]) //headers can be obtained from the first entry
                const values = Object.values(results)
    
                let table = document.createElement("table") //create table element
    
                let tr = table.insertRow(-1) //insert new row at last position               
    
                // For each header create a table header
                for(const header of headers)
                {
                    let th = document.createElement("th")     
                    th.innerHTML = header
                    tr.appendChild(th)
                }
    
                // Iterate each entry in values
                for(const row of values)
                {
                    let tr = table.insertRow(-1) // insert new row at last position for the current entry 
    
                    // for the current row, iterate over each key/header and insert its corresponding value into a cell
                    for(const key of Object.keys(row))
                    {
                        let tabCell = tr.insertCell(-1) //insert a cell at last position
                        tabCell.innerHTML = row[key] // insert the corresponding value given the key
                    }
                }
                
                // Append table to result element
                const container = document.getElementById('getResultsIDLevels')
                container.innerHTML = ''
                container.appendChild(table)
            }
            else
            {
                //Display message when no information was retrieved
                const container = document.getElementById('getResultsIDLevels')
                container.innerHTML = 'No results to show.'
            }
        }
        else{
            getResults.innerHTML = response.status
        }
    }



    // Insert/Post
    document.getElementById('formInsertLevels').onsubmit = async(e)=>
    {
        e.preventDefault() //prevent automatic page reload

        const data = new FormData(formInsertLevels)
        const dataObj = Object.fromEntries(data.entries())

        let response = await fetch('http://localhost:5000/api/levels',{
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(dataObj)
        })
        
        if(response.ok)
        {
            let results = await response.json() //save api response as json
            console.log(results)
            postResultsLevels.innerHTML = results.message // display result in id=postResults element
        }
        else{
            postResultsLevels.innerHTML = response.status //if response wasn't status 200 display status
        }
    }

    // Put/Update
    document.getElementById('formUpdateLevels').onsubmit = async(e)=>
    {
        e.preventDefault() //prevent automatic page reload

        const data = new FormData(formUpdateLevels)
        const dataObj = Object.fromEntries(data.entries())

        let response = await fetch('http://localhost:5000/api/levels',{
            method: 'PUT',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(dataObj)
        })
        
        if(response.ok)
        {
            let results = await response.json() //save api response as json
        
            console.log(results)
            putResultsLevels.innerHTML = results.message // display result in id=putResults element
        }
        else{
            putResultsLevels.innerHTML = response.status //if response wasn't status 200 display status
        }
    }

    // Delete
    document.getElementById('formDeleteLevels').onsubmit = async(e)=>
    {
        e.preventDefault() //prevent automatic page reload

        const data = new FormData(formDeleteLevels)
        const dataObj = Object.fromEntries(data.entries())

        let response = await fetch(`http://localhost:5000/api/levels/${dataObj['id_level']}`,{
            method: 'DELETE'
        })
        
        if(response.ok)
        {
            let results = await response.json() //save api response as json
            deleteResultsLevels.innerHTML = results.message // display result in id=deleteResults element
        }
        else
        {
            //if response wasn't status 200 display error message with status
            deleteResultsLevels.innerHTML = `Error!\nStatus: ${response.status} Message: ${results.message}`
        }
    }

    // RATINGS TABLE -----------------------------------------------------------------------------------------------------
    // Select 
    document.getElementById('formSelectRatings').onsubmit = async (e) =>
    {
        e.preventDefault() //prevent automatic page reload

        const data = new FormData(formSelectRatings)
        const dataObj = Object.fromEntries(data.entries()) // get entries section from data obj (which contains the actual info)

        let response = await fetch(`http://localhost:5000/api/ratings/${dataObj['id_rating']}`,{
            method: 'GET'
        })
        
        if(response.ok)
        {
            let results = await response.json() // saved fetched info as json
        
            //Generate table
            if(results.length > 0)
            {
                //Get table headers and values
                const headers = Object.keys(results[0]) //headers can be obtained from the first entry
                const values = Object.values(results)
    
                let table = document.createElement("table") //create table element
    
                let tr = table.insertRow(-1) //insert new row at last position               
    
                // For each header create a table header
                for(const header of headers)
                {
                    let th = document.createElement("th")     
                    th.innerHTML = header
                    tr.appendChild(th)
                }
    
                // Iterate each entry in values
                for(const row of values)
                {
                    let tr = table.insertRow(-1) // insert new row at last position for the current entry 
    
                    // for the current row, iterate over each key/header and insert its corresponding value into a cell
                    for(const key of Object.keys(row))
                    {
                        let tabCell = tr.insertCell(-1) //insert a cell at last position
                        tabCell.innerHTML = row[key] // insert the corresponding value given the key
                    }
                }
                
                // Append table to result element
                const container = document.getElementById('getResultsIDRatings')
                container.innerHTML = ''
                container.appendChild(table)
            }
            else
            {
                //Display message when no information was retrieved
                const container = document.getElementById('getResultsIDRatings')
                container.innerHTML = 'No results to show.'
            }
        }
        else{
            getResults.innerHTML = response.status
        }
    }



    // Insert/Post
    document.getElementById('formInsertRatings').onsubmit = async(e)=>
    {
        e.preventDefault() //prevent automatic page reload

        const data = new FormData(formInsertRatings)
        const dataObj = Object.fromEntries(data.entries())

        let response = await fetch('http://localhost:5000/api/ratings',{
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(dataObj)
        })
        
        if(response.ok)
        {
            let results = await response.json() //save api response as json
            console.log(results)
            postResultsRatings.innerHTML = results.message // display result in id=postResults element
        }
        else{
            postResultsRatings.innerHTML = response.status //if response wasn't status 200 display status
        }
    }

    // Put/Update
    document.getElementById('formUpdateRatings').onsubmit = async(e)=>
    {
        e.preventDefault() //prevent automatic page reload

        const data = new FormData(formUpdateRatings)
        const dataObj = Object.fromEntries(data.entries())

        let response = await fetch('http://localhost:5000/api/ratings',{
            method: 'PUT',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(dataObj)
        })
        
        if(response.ok)
        {
            let results = await response.json() //save api response as json
        
            console.log(results)
            putResultsRatings.innerHTML = results.message // display result in id=putResults element
        }
        else{
            putResultsRatings.innerHTML = response.status //if response wasn't status 200 display status
        }
    }

    // Delete
    document.getElementById('formDeleteRatings').onsubmit = async(e)=>
    {
        e.preventDefault() //prevent automatic page reload

        const data = new FormData(formDeleteRatings)
        const dataObj = Object.fromEntries(data.entries())

        let response = await fetch(`http://localhost:5000/api/ratings/${dataObj['id_rating']}`,{
            method: 'DELETE'
        })
        
        if(response.ok)
        {
            let results = await response.json() //save api response as json
            deleteResultsRatings.innerHTML = results.message // display result in id=deleteResults element
        }
        else
        {
            //if response wasn't status 200 display error message with status
            deleteResultsRatings.innerHTML = `Error!\nStatus: ${response.status} Message: ${results.message}`
        }
    }


    // GAMEPLAYS TABLE -----------------------------------------------------------------------------------------------------
    // Select 
    document.getElementById('formSelectGameplays').onsubmit = async (e) =>
    {
        e.preventDefault() //prevent automatic page reload

        const data = new FormData(formSelectGameplays)
        const dataObj = Object.fromEntries(data.entries()) // get entries section from data obj (which contains the actual info)

        let response = await fetch(`http://localhost:5000/api/gameplays/${dataObj['id_gameplay']}`,{
            method: 'GET'
        })
        
        if(response.ok)
        {
            let results = await response.json() // saved fetched info as json
        
            //Generate table
            if(results.length > 0)
            {
                //Get table headers and values
                const headers = Object.keys(results[0]) //headers can be obtained from the first entry
                const values = Object.values(results)
    
                let table = document.createElement("table") //create table element
    
                let tr = table.insertRow(-1) //insert new row at last position               
    
                // For each header create a table header
                for(const header of headers)
                {
                    let th = document.createElement("th")     
                    th.innerHTML = header
                    tr.appendChild(th)
                }
    
                // Iterate each entry in values
                for(const row of values)
                {
                    let tr = table.insertRow(-1) // insert new row at last position for the current entry 
    
                    // for the current row, iterate over each key/header and insert its corresponding value into a cell
                    for(const key of Object.keys(row))
                    {
                        let tabCell = tr.insertCell(-1) //insert a cell at last position
                        tabCell.innerHTML = row[key] // insert the corresponding value given the key
                    }
                }
                
                // Append table to result element
                const container = document.getElementById('getResultsIDGameplays')
                container.innerHTML = ''
                container.appendChild(table)
            }
            else
            {
                //Display message when no information was retrieved
                const container = document.getElementById('getResultsIDGameplays')
                container.innerHTML = 'No results to show.'
            }
        }
        else{
            getResults.innerHTML = response.status
        }
    }



    // Insert/Post
    document.getElementById('formInsertGameplays').onsubmit = async(e)=>
    {
        e.preventDefault() //prevent automatic page reload

        const data = new FormData(formInsertGameplays)
        const dataObj = Object.fromEntries(data.entries())

        let response = await fetch('http://localhost:5000/api/gameplays',{
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(dataObj)
        })
        
        if(response.ok)
        {
            let results = await response.json() //save api response as json
            console.log(results)
            postResultsGameplays.innerHTML = results.message // display result in id=postResults element
        }
        else{
            postResultsGameplays.innerHTML = response.status //if response wasn't status 200 display status
        }
    }

    // Put/Update
    document.getElementById('formUpdateGameplays').onsubmit = async(e)=>
    {
        e.preventDefault() //prevent automatic page reload

        const data = new FormData(formUpdateGameplays)
        const dataObj = Object.fromEntries(data.entries())

        let response = await fetch('http://localhost:5000/api/gameplays',{
            method: 'PUT',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(dataObj)
        })
        
        if(response.ok)
        {
            let results = await response.json() //save api response as json
        
            console.log(results)
            putResultsGameplays.innerHTML = results.message // display result in id=putResults element
        }
        else{
            putResultsGameplays.innerHTML = response.status //if response wasn't status 200 display status
        }
    }

    // Delete
    document.getElementById('formDeleteGameplays').onsubmit = async(e)=>
    {
        e.preventDefault() //prevent automatic page reload

        const data = new FormData(formDeleteGameplays)
        const dataObj = Object.fromEntries(data.entries())

        let response = await fetch(`http://localhost:5000/api/gameplays/${dataObj['id_gameplay']}`,{
            method: 'DELETE'
        })
        
        if(response.ok)
        {
            let results = await response.json() //save api response as json
            deleteResultsGameplays.innerHTML = results.message // display result in id=deleteResults element
        }
        else
        {
            //if response wasn't status 200 display error message with status
            deleteResultsGameplays.innerHTML = `Error!\nStatus: ${response.status} Message: ${results.message}`
        }
    }
}

main()