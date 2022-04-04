import React from 'react';

import FirstLogin from '../LoginPage/FirstLogin';
 import Login from '../LoginPage/LoginPage';

function HomePage () {
   
    return (
        <div>
            {localStorage.getItem("token") ?

            (localStorage.getItem("isFirstLogin")==="True"?(<FirstLogin />):
            (localStorage.getItem("role")==="Admin")?(<div>Admin Page</div>)
            :(<div>User Page</div>))
            :(<><Login/></>)
            }
                    
                       
        </div>
    );
}
export default HomePage;