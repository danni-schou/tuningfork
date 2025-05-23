//-----------------------------------------------------------------------
// <copyright file="CInitializationSettings.cs" company="Google">
//
// Copyright 2020 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------


using System;
using System.Runtime.InteropServices;

namespace Google.Android.PerformanceTuner
{
    /// <summary>
    ///     Initialization settings.
    ///     Zero any values that are not being used.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CInitializationSettings
    {
        /// <summary>
        ///     Cache object to be used for upload data persistence.
        ///     If null, data is persisted to /data/local/tmp/tuningfork
        /// </summary>
        public IntPtr persistent_cache;

        /// <summary>
        ///     The address of the Swappy_injectTracers function.
        ///     If this is null, you need to call TuningFork_tick yourself.
        ///     If it is set, telemetry for 4 instrument keys is automatically recorded.
        /// </summary>
        public SwappyTracerFn swappy_tracer_fn;

        /// <summary>
        ///     Callback
        ///     If set, this is called with the fidelity parameters that are downloaded.
        ///     If null, you need to call TuningFork_getFidelityParameters yourself.
        /// </summary>
        public FidelityParamsCallback fidelity_params_callback;

        /// <summary>
        ///     A serialized protobuf containing the fidelity parameters to be uploaded for training.
        ///     Set this to nullptr if you are not using training mode.
        ///     In training mode, these parameters are taken to be the parameters used within the game
        ///     and they are used to help suggest parameter changes for different devices. Note that
        ///     these override the default parameters loaded from the APK at startup.
        /// </summary>
        public IntPtr training_fidelity_params;

        /// <summary>
        ///     A null-terminated UTF-8 string containing the endpoint that Tuning Fork will connect
        ///     to for parameter, upload and debug requests. This overrides the value in base_uri in
        ///     the settings proto and is intended for debugging purposes only.
        /// </summary>
        public IntPtr endpoint_uri_override;

        /// <summary>
        ///     The version of Swappy that swappy_tracer_fn comes from.
        /// </summary>
        public uint swappy_version;

        /// <summary>
        ///     The number of each metric that is allowed to be allocated at any given time. If any
        ///     element is zero, the default for that metric type will be used. Memory for all metrics
        ///     is allocated up-front at initialization. When all metrics of a given type are allocated,
        ///     further requested metrics will not be added and data will be lost.
        /// </summary>
        public MetricLimits max_num_metrics;

        /// <summary>
        ///     If non-null, this value overrides the api_key field in the app's
        ///     tuningfork_settings.bin file. See tuningfork.proto for more information.
        /// </summary>
        public IntPtr api_key;

        /// <summary>
        ///      If false, sensitive information is removed from native logging.
        /// </summary>
        public byte verbose_logging_enabled;
        
        /// <summary>
        ///      If true, disables additional native telemetry collection
        /// </summary>
        public byte disable_async_telemetry;
    }
}