using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    //Declare all Spaceship controls system this way so that you can edit the magnitude of the force applied to each control
    [System.Serializable]
    public class RollThrusters{
        public ShipThruster right1, right2;
        public ShipThruster left1, left2;
    }

    [System.Serializable]
    public class PitchThruster{
        public ShipThruster up;
        public ShipThruster down;
    }

    [System.Serializable]
    public class YawThruster{
        public ShipThruster right1, right2;
        public ShipThruster left1, left2;
    }
    public RollThrusters rollThruster;
    public PitchThruster pitchThruster;
    public YawThruster yawThruster;
    public ShipThruster mainThruster;
    public ShipThruster brake;
    public ShipThruster Left;
    public ShipThruster Right;
    public ShipThruster Up;
    public ShipThruster Down;
    public Hashtable torques;
    public Hashtable forces;

    private new Rigidbody rigidbody;
    float rollInput;
    float pitchInput;
    float YawInput;

    

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        torques = new Hashtable();
        forces = new Hashtable();
    }
    void FixedUpdate()
    {
        HandleRoll();
        HandlePitch();
        HandleYaw();
        HandleMainThruster();
        HandleTorques();
        HandleForces();
        HandleBrake();
        HandleLeft();
        HandleRight();
        HandleUp();
        HandleDown();
    }
    //All functions handling movements to the ship by starting and stopping the thrusts
    void HandleRoll()
    {
        if (RollRight()){
            rollThruster.right1.StartThrust();
            rollThruster.right2.StartThrust();
            rollThruster.left1.StopThrust();
            rollThruster.left2.StopThrust();
        }
        else if (RollLeft()){
            rollThruster.right1.StopThrust();
            rollThruster.right2.StopThrust();
            rollThruster.left1.StartThrust();
            rollThruster.left2.StartThrust();
        }
        else{
            rollThruster.right1.StopThrust();
            rollThruster.right2.StopThrust();
            rollThruster.left1.StopThrust();
            rollThruster.left2.StopThrust();
        }
    }
    void HandlePitch()
    {
        if (PitchUp()){
            pitchThruster.up.StartThrust();
            pitchThruster.down.StopThrust();
        }
        else if (PitchDown()){
            pitchThruster.up.StopThrust();
            pitchThruster.down.StartThrust();
        }
        else{
            pitchThruster.up.StopThrust();
            pitchThruster.down.StopThrust();
        }
    }
    void HandleYaw()
    {
        if (YawRight()){
            yawThruster.right1.StartThrust();
            yawThruster.right2.StartThrust();
            yawThruster.left1.StopThrust();
            yawThruster.left2.StopThrust();
        }
        else if (YawLeft()){
            yawThruster.right1.StopThrust();
            yawThruster.right2.StopThrust();
            yawThruster.left1.StartThrust();
            yawThruster.left2.StartThrust();
        }
        else{
            yawThruster.right1.StopThrust();
            yawThruster.right2.StopThrust();
            yawThruster.left1.StopThrust();
            yawThruster.left2.StopThrust();
        }
    }
    void HandleMainThruster()
    {
        if (MainThruster())
        {
            mainThruster.StartThrust();
        }
        else
        {
            mainThruster.StopThrust();
        }
    }
    void HandleBrake()
    {
        if (Brake())
        {
            brake.StartThrust();
        }
        else
        {
            brake.StopThrust();
        }
    }
    void HandleLeft()
    {
        if (LeftKey())
        {
            Left.StartThrust();
        }
        else
        {
            Left.StopThrust();
        }
    }
    void HandleRight()
    {
        if (RightKey())
        {
            Right.StartThrust();
        }
        else
        {
            Right.StopThrust();
        }
    }
    void HandleUp()
    {
        if (UpKey())
        {
            Up.StartThrust();
        }
        else
        {
            Up.StopThrust();
        }
    }
    void HandleDown()
    {
        if (DownKey())
        {
            Down.StartThrust();
        }
        else
        {
            Down.StopThrust();
        }
    }
    
    public void AddTorque(string id, Vector3 torque){
        if (torques.ContainsKey(id)) return;
        torques.Add(id, torque);

    }
    public void removeTorque(string id){
        if (!torques.ContainsKey(id)) return;
        torques.Remove(id);

    }
    public void AddForce(string id, Vector3 force){
        if (forces.ContainsKey(id)) return;
        forces.Add(id, force);

    }
    public void RemoveForce(string id){
        if (!forces.ContainsKey(id)) return;
        forces.Remove(id);

    }
    //Functions applying the Torque and Force to the ship
    void HandleTorques()
    {
        foreach (DictionaryEntry entry in torques)
        {
            Vector3 torque = (Vector3)entry.Value;
            rigidbody.AddRelativeTorque(torque);
        }
    }
    void HandleForces()
    {
        foreach(DictionaryEntry entry in forces){
            Vector3 force = (Vector3)entry.Value;
            rigidbody.AddRelativeForce(force);
        }
    }
    //All input keys to control the ship
    bool RollLeft(){
        if (Input.GetKey(KeyCode.Q)) return true; return false;
    }
    bool RollRight(){
        if (Input.GetKey(KeyCode.E)) return true; return false;
    }
    bool PitchUp(){
        if (Input.GetKey(KeyCode.S)) return true; return false;
    }
    bool PitchDown(){
        if (Input.GetKey(KeyCode.W)) return true; return false;
    }
    bool YawLeft(){
        if (Input.GetKey(KeyCode.A)) return true; return false;
    }
    bool YawRight(){
        if (Input.GetKey(KeyCode.D)) return true; return false;
    }
    bool MainThruster(){
        if (Input.GetKey(KeyCode.Space)) return true; return false;
    }
    bool Brake(){
        if (Input.GetKey(KeyCode.LeftShift)) return true; return false;
    }
    bool LeftKey(){
        if (Input.GetKey(KeyCode.LeftArrow)) return true; return false;
    }
    bool RightKey(){
        if (Input.GetKey(KeyCode.RightArrow)) return true; return false;
    }
    bool UpKey(){
        if (Input.GetKey(KeyCode.UpArrow)) return true; return false;
    }
    bool DownKey(){
        if (Input.GetKey(KeyCode.DownArrow)) return true; return false;
    }
}
