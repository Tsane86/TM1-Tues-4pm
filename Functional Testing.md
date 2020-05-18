<table>
  <tbody>
    <tr>
      <th>ID</th>
      <th>Description</th>
      <th>Prerequisites</th>
      <th>Procedure</th>
      <th>Test Data</th>
      <th>Pass/Fail</th>
      <th>Notes</th>
    </tr>
    <tr>
      <td>01</td>
      <td>Ability to register onto the system</td>
      <td>The user is on the "login" page of the website</td>
      <td>
        <ol>
            <li>The user clicks on the "I am a New User" option</li>
            <li>The user clicks on either the "I am a Doctor" or "I am a Patient" option</li>
            <li>The user enters their details in the form and clicks "Submit"</li>
            <li>The user is either rejected or registered based on the validity of their input on the form</li>
        </ol>
      </td>
      <td>
        <ul>
            <li>All acceptable test data is accepted so no false positives are present</li>
            <li>Incomplete emails without a top level domain can be accepted e.g. johndoe@gmail</li>
            <li>No restrictions are put in place for medicare number, first name, last name, password, adress, suburb, and postcode</li>
            <li>Reset button worked effectively</li>
        </ul>
      </td>
      <td>
        <ul>
            <li> - [x] System does not reject acceptable user input</li>
            <li> - [ ] Once submitting, system is able to store user information </li>
            <li> - [ ] System was able to reject submission with invalid information </li>
        </ul>
      </td>
      <td>After submitting, I repeatedly into an error stating "A database operation failed while processing the request." I tried a few things to fix it but was unable to come up with a solution.</td>
    </tr>
  </tbody>
</table>
