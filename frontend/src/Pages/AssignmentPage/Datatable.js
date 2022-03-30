import React, { useEffect, useState } from "react";
import axios from "axios";
import { makeStyles } from "@mui/styles";
import Button from "@mui/material/Button";
import { Link } from "react-router-dom";
import TextField from "@mui/material/TextField";
import {
  DataGrid,
  gridPageCountSelector,
  gridPageSelector,
  useGridApiContext,
  useGridSelector,
} from "@mui/x-data-grid";
import Pagination from "@mui/material/Pagination";
import Popup from "../../Components/Modal/Popup";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import ChangeCircleIcon from "@mui/icons-material/ChangeCircle";
import InfoIcon from "@mui/icons-material/Info";
import RemoveCircleOutlineIcon from "@mui/icons-material/RemoveCircleOutline";

function CustomPagination() {
  const apiRef = useGridApiContext();
  const page = useGridSelector(apiRef, gridPageSelector);
  const pageCount = useGridSelector(apiRef, gridPageCountSelector);

  return (
    <Pagination
      color="error"
      count={pageCount}
      page={page + 1}
      onChange={(event, value) => apiRef.current.setPage(value - 1)}
    />
  );
}
const styles = makeStyles({
  table: {
    // boxShadow: "2px 2px 5px -1px rgba(0,0,0,0.75)",
    width: "cover",
    margin: "25px 50px 0 50px",
  },
});
const Datatable = () => {
  const [gridData, setGridData] = useState([]);
  const [loading, setLoading] = useState(false);
  const [searchText, setSearchText] = useState("");
  let [filteredData] = useState();
  const [openPopup, setOpenPopup] = useState(false);
  const [disable] = useState(false);
  const [selectedItem, setSelectedItem] = useState(null);

  useEffect(() => {
    loadData();
  }, []);

  const loadData = async () => {
    setLoading(true);
    const response = await axios.get(
      "https://jsonplaceholder.typicode.com/users"
    );
    setGridData(response.data);
    setLoading(false);
  };

  const modifiedData = gridData.filter(item => {
    return item.name.includes(searchText)  
  }).map(({ ...item }) => ({
    ...item,
    key: item.id,
  }));

  const handleDelete = (value) => {
    const dataSource = [...modifiedData];
    const filteredData = dataSource.filter((item) => item.id !== value.id);
    setGridData(filteredData);
  };

  const toggleChangeStatus = (value) => {
    const dataSource = [...modifiedData];
    const filteredData = dataSource.map((item) => {
      if (item.id === value.id) {
        return {
          ...item,
          isDisable: !item.isDisable,
        }
      }
      return item;
    });
    setGridData(filteredData);
  };

  const classes = styles();
  const columns = [
    {
      headerName: "ID",
      field: "id",
      width: 100,
      disableColumnMenu: true,
    },
    {
      headerName: "Asset Code",
      field: "name",
      width: 150,
    },
    {
      headerName: "Asset Name",
      field: "username",
      width: 250,
    },
    {
      headerName: "Assigned To",
      field: "email",
      width: 200,
    },
    {
      headerName: "Assigned By",
      field: "website",
      width: 200,
    },
    {
      headerName: "Assigned By",
      field: "website",
      width: 200,
    },
    {
      headerName: "Assigned State",
      field: "phone",
      width: 200,
    },
    {
      headerName: "Actions",
      field: "actions",
      width: 250,
      sortable: false,
      disableColumnMenu: true,
      renderCell: (item) => {
        return (
          (
            <div>
              <Button
                size="small"
                color="error"
                onClick={() => handleDelete(item)}
              >
                <RemoveCircleOutlineIcon fontSize="small" />
              </Button>
            
              <Button
                disabled={item.row.isDisable}
                size="small"
                color="secondary"
                onClick={() => {
                  setOpenPopup(true);
                  setSelectedItem(item);
                }}
              >
                <ChangeCircleIcon fontSize="small" />
              </Button>
  
              <Link style={{ textDecoration: "none" }} to={`/posts/${item.id}`}>
                <Button size="small">
                  <InfoIcon fontSize="small" />
                </Button>
              </Link>
            </div>
          ) 
        )
      }
    },
  ];

  const handleSearch = (e) => {
    setSearchText(e.target.value);
  };
  return (
    <div>
      <div>
        <TextField
          id="outlined-basic"
          label="Search"
          variant="outlined"
          onChange={handleSearch}
          value={searchText}
          size="small"
        />
      </div>

      <div className={classes.table}>
        <DataGrid
          pagination
          autoHeight
          {...modifiedData}
          columns={columns}
          rows={
             modifiedData
          }
          pageSize={5}
          rowsPerPageOptions={[10]}
          loading={loading}
          components={{
            Pagination: CustomPagination,
          }}
        />
      </div>

      <Popup
        title="Are you sure?"
        openPopup={openPopup}
        setOpenPopup={setOpenPopup}
      >
        <div>
          <p>Do you want to create a returning request for this asset?</p>
        </div>
        <Button
          variant="contained"
          color="error"
          onClick={() => {
            setOpenPopup(false);
            setGridData();
            toggleChangeStatus(selectedItem);
            setSelectedItem(null);
          }}
        >
          Yes
        </Button>
        <Button
          color="secondary"
          onClick={() => {
            setOpenPopup(false);
          }}
        >
          No
        </Button>
      </Popup>
    </div>
  );
};

export default Datatable;
