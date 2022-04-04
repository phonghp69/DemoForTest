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
    width: "cover",
    margin: "25px 50px 0 50px",
  },
});
const Datatable = () => {
  const [gridData, setGridData] = useState([]);
  const [loading, setLoading] = useState(false);
  const [searchText, setSearchText] = useState("");

  useEffect(() => {
    loadData();
  }, []);

  const loadData = async () => {
    setLoading(true);
    const response = await axios.get(
      `${process.env.Backend_URI}/Asset/all`
    );
    setGridData(response.data);
    setLoading(false);
  };

  const modifiedData = gridData.filter(item => {
    return item.assetName.includes(searchText)  
  }).map(({ ...item }) => ({
    ...item,
    key: item.assetId,
  }));

  const handleDelete = (value) => {
    const dataSource = [...modifiedData];
    const filteredData = dataSource.filter((item) => item.assetId !== value.id);
    setGridData(filteredData);
  };


  const classes = styles();
  const columns = [
    {
      headerName: "ID",
      field: "assetId",
      width: 100,
      disableColumnMenu: true,
    },
    {
      headerName: "Asset Code",
      field: "assetCode",
      width: 150,
    },
    {
      headerName: "Asset Name",
      field: "assetName",
      width: 250,
    },
    {
      headerName: "Category",
      field: "categoryName",
      width: 200,
    },
    {
      headerName: "State",
      field: "assetState",
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
            
  
              <Link style={{ textDecoration: "none" }} to={`/asset/${item.id}`}>
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
          getRowId={row => row.assetId}
        />
      </div>
    </div>
  );
};

export default Datatable;
