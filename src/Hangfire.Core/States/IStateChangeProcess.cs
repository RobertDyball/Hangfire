﻿// This file is part of Hangfire.
// Copyright © 2013-2014 Sergey Odinokov.
// 
// Hangfire is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as 
// published by the Free Software Foundation, either version 3 
// of the License, or any later version.
// 
// Hangfire is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public 
// License along with Hangfire. If not, see <http://www.gnu.org/licenses/>.

using Hangfire.Storage;

namespace Hangfire.States
{
    /// <summary>
    /// Provides a mechanism for running state election and state applying processes.
    /// </summary>
    /// 
    /// <seealso cref="DefaultStateChangeProcess"/>
    public interface IStateChangeProcess
    {
        /// <summary>
        /// Performs the state election process, where a new state will be elected
        /// for a background job depending on state election rules.
        /// </summary>
        /// <param name="connection">The current connection for a state election process.</param>
        /// <param name="context">The context of a state election process.</param>
        void ElectState(IStorageConnection connection, ElectStateContext context);

        /// <summary>
        /// Performs the state applying process, where a current background job
        /// will be moved to the elected state.
        /// </summary>
        /// <param name="transaction">The current transaction for a state applying process.</param>
        /// <param name="context">The context of a state applying process.</param>
        void ApplyState(IWriteOnlyTransaction transaction, ApplyStateContext context);
    }
}
